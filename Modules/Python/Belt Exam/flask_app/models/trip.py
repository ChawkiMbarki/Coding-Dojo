# import the function that will return an instance of a connection
from flask_app.config.mysqlconnection import connectToMySQL
from flask_app.models import validation as val
from flask import flash

class Trip:
    def __init__(self, data):
        self.id = data['id']
        self.destination = data['destination']
        self.start_date = data['start_date']
        self.end_date = data['end_date']
        self.plan = data['plan']
        self.creator_id = data['creator_id']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']

    @staticmethod
    def save(data):
        query = """INSERT INTO trips (destination, start_date, end_date, plan, creator_id)
                    VALUES (%(destination)s, %(start_date)s, %(end_date)s, %(plan)s, %(creator_id)s)"""
        trip_id = connectToMySQL().query_db(query, data)
        data = {
            'user_id': data['creator_id'],
            'trip_id': trip_id
        }
        query = """INSERT INTO register (user_id, trip_id)
                    VALUES
                    (%(user_id)s, %(trip_id)s)"""
        return connectToMySQL().query_db(query, data)

    @classmethod
    def get_trip(cls, data):
        query = "SELECT * FROM trips WHERE id = %(id)s;"
        return cls(connectToMySQL().query_db(query, data)[0])

    @classmethod
    def get_all(cls):
        query = "SELECT * FROM trips;"
        return cls(connectToMySQL().query_db(query))

    @classmethod
    def get_user_trips(cls, data):
        query = """SELECT *
                    FROM trips t
                    JOIN register r ON t.id = r.trip_id
                    WHERE r.user_id = %(id)s;"""
        result = connectToMySQL().query_db(query, data)
        user_trips = []
        for i in result:
            user_trips.append(cls(i))
        
        return user_trips

    @classmethod
    def get_other_trips(cls, data):
        query = """SELECT *
                    FROM trips t
                    LEFT JOIN register r ON t.id = r.trip_id AND r.user_id = %(id)s
                    WHERE r.user_id IS NULL;"""
        result = connectToMySQL().query_db(query, data)
        other_trips = []
        for i in result:
            other_trips.append(cls(i))
        return other_trips

    @staticmethod
    def join(data):
        query = """INSERT INTO register (user_id, trip_id)
                    VALUES
                    (%(user_id)s, %(trip_id)s)"""
        return connectToMySQL().query_db(query, data)

    @staticmethod
    def update(data):
        query = """UPDATE trips SET
                    destination = %(destination)s,
                    start_date = %(start_date)s,
                    end_date = %(end_date)s,
                    plan = %(plan)s
                    WHERE id = %(id)s
        """
        return connectToMySQL().query_db(query, data)

    @staticmethod
    def cancel(data):
        query = """DELETE FROM register
                    WHERE user_id = %(user_id)s
                    AND trip_id = %(trip_id)s"""
        return connectToMySQL().query_db(query, data)

    @staticmethod
    def remove(data):
        query = """DELETE FROM trips
                    WHERE id = %(trip_id)s;"""
        return connectToMySQL().query_db(query, data)

    @staticmethod
    def creator(data):
        query = """SELECT * FROM users
                    WHERE id = %(id)s;"""
        return connectToMySQL().query_db(query, data)[0]

    @staticmethod
    def guests_ids(data):
        query = """SELECT users.id FROM users
                    INNER JOIN register ON users.id = register.user_id
                    INNER JOIN trips ON register.trip_id = trips.id
                    WHERE trips.id = %(id)s;"""
        users = connectToMySQL().query_db(query, data)
        users_ids = []
        for user_id in users:
            users_ids.append(user_id['id'])
        return users_ids


    @classmethod
    def validate(cls, trip):
        errors = []
        
        if(not val.validate_destination(trip['destination'])):
            error = "Destination - Must be At least 3 characters"
            errors.append(error)
            flash(error, 'error')
        
        if(not val.validate_plan(trip['plan'])):
            error = "Plan - Must be provided!"
            errors.append(error)
            flash(error, 'error')
        time_travel = False
        if(not val.validate_start_date(trip['start_date'])):
            time_travel = True
            error = "Time travel is not allowed - Start Date must be in the future"
            errors.append(error)
            flash(error, 'error')
        
        if(not val.validate_end_date(trip['start_date'], trip['end_date'])):
            error = "Time travel is not allowed - End Date Must be after the start date"
            errors.append(error)
            flash(error, 'error')

        return errors
# import the function that will return an instance of a connection
from flask_app.config.mysqlconnection import connectToMySQL
from flask_app.models import validation as val
from flask import flash

class User:
    def __init__(self, data):
        self.id = data['id']
        self.first_name = data['first_name']
        self.last_name = data['last_name']
        self.email = data['email']
        self.password = data['password']

    @classmethod
    def get_user(cls, data):
        query = "SELECT * FROM users WHERE id = %(id)s;"
        return cls(connectToMySQL().query_db(query, data)[0])

    @classmethod
    def get_by_email(cls, data):
        query = "SELECT * FROM users WHERE email = %(email)s;"
        result = connectToMySQL().query_db(query,data)
        if len(result) < 1:
            return False
        return cls(result[0])

    @staticmethod
    def save(data):
        query = "INSERT INTO users (first_name, last_name, email, password) VALUES (%(first_name)s, %(last_name)s, %(email)s, %(password)s)"
        return connectToMySQL().query_db(query, data)

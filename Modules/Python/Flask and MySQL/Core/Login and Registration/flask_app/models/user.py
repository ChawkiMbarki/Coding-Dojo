# import the function that will return an instance of a connection
from flask_app.config.mysqlconnection import connectToMySQL
from flask_app.models import validation as val
from flask import flash

class User:
    DB = "users_crud"
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


    @classmethod
    def validate_registration(cls, user):
        errors = []
        
        if(not val.validate_name(user['first_name'])):
            error = "First Name - Must be letters only, at least 2 characters"
            errors.append(error)
            flash(error, 'error')
        
        if(not val.validate_name(user['last_name'])):
            error = "Last Name - Must be letters only, at least 2 characters"
            errors.append(error)
            flash(error, 'error')
        
        if(not val.validate_email(user['email']) or (cls.get_by_email({"email": user['email']}))):
            error = "Email - Must be in valid format, and isn't already linked with another account"
            errors.append(error)
            flash(error, 'error')
        
        if(not val.validate_password(user['password'])):
            error = "Password - Must be At least 8 characters"
            errors.append(error)
            flash(error, 'error')
        
        if(not user['confirm_password'] == user['password']):
            error = "Password Confirmation - Must be the same as the password"
            errors.append(error)
            flash(error, 'error')
        
        return errors

    @classmethod
    def validate_login(cls, user):
        errors = []
        usr = cls.get_by_email({"email": user['login_email']})
        if(not val.validate_email(user['login_email'])): 
            error = "Email - Must be in valid format"
            errors.append(error)
            flash(error, 'error')
        
        if (not usr):
            error = "Password or Email is wrong"
            errors.append(error)
            flash(error, 'error')
        
        if(not val.validate_password(user['login_password'])): 
            error = "Password - Must be At least 8 characters"
            errors.append(error)
            flash(error, 'error')
        
        return errors
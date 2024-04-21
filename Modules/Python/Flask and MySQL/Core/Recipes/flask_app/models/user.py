from flask import flash
from flask_app.models import validation as val
from flask_app.config.mysqlconnection import connectToMySQL

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

  # other class methods remain unchanged


  @classmethod
  def get_by_email(cls, data):
    # Get a user by their email
    query = "SELECT * FROM users WHERE email = %(email)s;"
    result = connectToMySQL().query_db(query, data)
    if result:
      return cls(result[0])
    return False

  @staticmethod
  def save(data):
    # Save a new user
    query = "INSERT INTO users (first_name, last_name, email, password) VALUES (%(first_name)s, %(last_name)s, %(email)s, %(password)s)"
    return connectToMySQL().query_db(query, data)

  def validate_registration(user):
    # Define validation functions and error messages
    validations = {
      'first_name': (val.validate_name, "First Name - Must be letters only, at least 2 characters"),
      'last_name': (val.validate_name, "Last Name - Must be letters only, at least 2 characters"),
      'email': (val.validate_email, "Email - Must be in valid format"),
      'password': (val.validate_password, "Password - Must be at least 8 characters"),
      'confirm_password': (lambda x: x == user['password'], "Password Confirmation - Must be the same as the password")
    }
    # this checks for errors
    errors = []
    for field, (validation_func, error_message) in validations.items():
      if not validation_func(user[field]):
        errors.append(error_message)
        flash(errors[-1], 'error')
    
    # Check if email already exists
    if not errors and User.get_by_email({"email": user['email']}):
      errors.append("Your Email is already linked with another account")
      flash(errors[-1], 'error')
    
    return errors


  @classmethod
  def validate_login(cls, user):
    # Define validation functions and error messages
    validation = {
      'login_email': (val.validate_email, "Email - Must be in valid format"),
      'login_password': (val.validate_password, "Password - Must be at least 8 characters")
    }
    
    # Validate user login data
    errors = []
    
    for field, (validation_func, error_message) in validation.items():
      if not validation_func(user[field]):
        errors.append(error_message)
        flash(error_message, 'error')
      
    # Check if email and password combination exists
    if not errors:
      usr = cls.get_by_email({"email": user['login_email']})
      if not usr:
        errors.append("Password or Email is wrong")
        flash("Password or Email is wrong", 'error')
    
    return errors
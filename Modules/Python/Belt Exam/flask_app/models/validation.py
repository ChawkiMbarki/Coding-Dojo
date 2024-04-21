import re
from datetime import datetime

def validate_name(name):
  NAME_REGEX = re.compile(r'^[a-zA-Z]+$')
  if((len(name) < 2) or not NAME_REGEX.match(name)):
    return False #("First Name - Must be letters only, at least 2 characters")
  return True

def validate_email(email):
  EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
  if(not EMAIL_REGEX.match(email)): 
    return False #("Email - Must be in valid format, isn't already linked with another account")
  return True

def validate_password(password):
  if(len(password) < 8): 
    return False #("Password - Must be At least 8 characters")
  return True

def validate_destination(destination):
  if(len(destination) < 3): 
    return False #("Destination - Must be At least 3 characters")
  return True

def validate_start_date(start_date):
  try:
        start_date = datetime.strptime(start_date, '%Y-%m-%d')
        current_date = datetime.now()
        return start_date >= current_date
  except ValueError:
        return False #("Start Date - Must be in the future")

def validate_end_date(start_date, end_date):
  try:
        start_date = datetime.strptime(start_date, '%Y-%m-%d')
        end_date = datetime.strptime(end_date, '%Y-%m-%d')
        return end_date >= start_date
  except ValueError:
        return False #("End Date - Must be after the start date")

def validate_plan(plan):
  if(len(plan) == 0): 
    return False #("Plan - Must be provided!")
  return True

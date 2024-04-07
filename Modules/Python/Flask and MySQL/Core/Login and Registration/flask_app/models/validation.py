import re

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


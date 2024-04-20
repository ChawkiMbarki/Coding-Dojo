import re

def validate_name(name):
  NAME_REGEX = re.compile(r'^[a-zA-Z]+$')
  return len(name) >= 2 and NAME_REGEX.match(name)

def validate_email(email):
  EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
  return EMAIL_REGEX.match(email)

def validate_password(password):
  return len(password) >= 8

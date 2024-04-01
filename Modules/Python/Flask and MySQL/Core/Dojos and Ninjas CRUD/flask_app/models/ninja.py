from flask_app.config.mysqlconnection import connectToMySQL

class Ninja:

  def __init__(self, data):
    self.id = data['id']
    self.first_name = data['first_name']
    self.last_name = data['last_name']
    self.age = data['age']
    self.dojo_id = data['dojo_id']
    self.created_at = data['created_at']
    self.updated_at = data['updated_at']

  @classmethod
  def save(cls, data):
    query = "INSERT INTO ninjas (first_name, last_name, age, dojo_id) VALUES(%(first_name)s, %(last_name)s, %(age)s, %(dojo_id)s);"
    return connectToMySQL().query_db(query, data)
  
  @classmethod
  def get(cls, id):
    data = {'id': id}
    query = "SELECT * FROM ninjas WHERE id = %(id)s;"
    return cls(connectToMySQL().query_db(query, data)[0])
  
  @classmethod
  def get_all(cls):
    query = "SELECT * FROM ninjas;"
    result = connectToMySQL().query_db(query)
    ninjas = []
    for ninja in result:
      ninjas.append(cls(ninja))
    return ninjas
  
  @classmethod
  def dojo_ninjas(cls, id):
    data = {'id': id}
    query = "SELECT * FROM ninjas WHERE dojo_id = %(id)s;"
    result = connectToMySQL().query_db(query, data)
    ninjas = []
    for ninja in result:
      ninjas.append(cls(ninja))
    return ninjas
  

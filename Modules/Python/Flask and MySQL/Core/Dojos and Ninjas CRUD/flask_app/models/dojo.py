from flask_app.config.mysqlconnection import connectToMySQL

class Dojo:

  def __init__(self, data):
    self.id = data['id']
    self.name = data['name']
    self.created_at = data['created_at']
    self.updated_at = data['updated_at']

  @classmethod
  def save(cls, data):
    query = "INSERT INTO dojos (name) VALUES(%(name)s);"
    return connectToMySQL().query_db(query, data)
  
  @classmethod
  def get(cls, id):
    data = {'id': id}
    query = "SELECT * FROM dojos WHERE id = %(id)s;"
    return cls(connectToMySQL().query_db(query, data)[0])
  
  @classmethod
  def get_all(cls):
    query = "SELECT * FROM dojos;"
    result = connectToMySQL().query_db(query)
    dojos = []
    for dojo in result:
      dojos.append(cls(dojo))
    return dojos
  

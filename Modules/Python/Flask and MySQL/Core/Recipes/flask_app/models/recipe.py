# import the function that will return an instance of a connection
from flask_app.config.mysqlconnection import connectToMySQL

class recipes:
    def __init__(self, data):
        self.id = data['id']
        self.name = data['name']
        self.description = data['description']
        self.instructions = data['instructions']
        self.created_at = data['created_at']
        self.under_30 = data['under_30']
        self.owner_id = data['owner_id']

    @classmethod
    def get_all(cls):
        query = "SELECT * FROM recipes;"
        return cls(connectToMySQL().query_db(query))
    
    @classmethod
    def get_recipe(cls, data):
        query = "SELECT * FROM recipes WHERE id = %(id)s;"
        return cls(connectToMySQL().query_db(query, data)[0])

    @staticmethod
    def save(data):
        query = "INSERT INTO recipes (name, description, instructions, created_at, under_30, owner_id) VALUES (%(name)s, %(description)s, %(instructions)s, %(created_at)s, %(under_30)s, %(owner_id)s)"
        return connectToMySQL().query_db(query, data)
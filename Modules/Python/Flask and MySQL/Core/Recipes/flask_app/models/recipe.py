from flask_app.config.mysqlconnection import connectToMySQL
from flask import flash

class Recipes:
  def __init__(self, data):
      self.id = data['id']
      self.name = data['name']
      self.description = data['description']
      self.instructions = data['instructions']
      self.created_at = data['created_at']
      self.under_30 = data['under_30']
      self.owner_id = data['owner_id']

  @staticmethod
  def save(data):
      # Saves a recipe
      query = """INSERT INTO recipes 
                (name, description, instructions, created_at, under_30, owner_id) 
                VALUES
                (%(name)s, %(description)s, %(instructions)s, %(created_at)s, %(under_30)s, %(owner_id)s)"""
      return connectToMySQL().query_db(query, data)

    
  @classmethod
  def get_recipe(cls, data):
    # Retrieve a single recipe from the database based on its ID
    query = "SELECT * FROM recipes WHERE id = %(id)s;"
    result = connectToMySQL().query_db(query, data)
    if result:
      return cls(result[0])
    else:
      return None

  @classmethod
  def get_all(cls):
    # Retrieve all recipes from the database along with their owners' names
    query = """SELECT r.id, r.name, r.description, r.instructions, r.created_at, r.under_30, r.owner_id, u.first_name AS owner_name
                FROM recipes r
                JOIN users u on r.owner_id = u.id;"""
    results = connectToMySQL().query_db(query)
    recipes = []
    for result in results:
      recipe = cls(result)
      recipe.owner_name = result['owner_name']
      recipes.append(recipe)
    return recipes

  @classmethod
  def get_user_recipes(cls, data):
    # Retrieve recipes created by a specific user
    query = """SELECT *
                FROM recipes r
                JOIN users u ON r.id = u.id
                WHERE u.id = %(id)s;"""
    results = connectToMySQL().query_db(query, data)
    return [cls(result) for result in results]

  @classmethod
  def get_other_recipes(cls, data):
    # Retrieve recipes created by other users
    query = """SELECT *
                FROM recipes r
                LEFT JOIN users u ON u.id = r.creator_id AND r.creator_id != %(id)s;"""
    results = connectToMySQL().query_db(query, data)
    return [cls(result) for result in results]

  @staticmethod
  def remove(data):
    # Delete a recipe from the database
    query = """DELETE FROM recipes
                WHERE id = %(recipe_id)s;"""
    return connectToMySQL().query_db(query, data)

  @staticmethod
  def favorite(data):
    # Add a recipe to the user's favorites
    query = 'INSERT INTO favorite (user_id, recipe_id) VALUES (%(user_id)s, %(recipe_id)s)'
    return connectToMySQL().query_db(query, data)
  
  @staticmethod
  def unfavorite(data):
    # Remove a recipe from the user's favorites
    query = """DELETE FROM favorite
                WHERE user_id = %(user_id)s
                AND recipe_id = %(recipe_id)s"""
    return connectToMySQL().query_db(query, data)

  @staticmethod
  def favorited_your_recipe(data):
    # Retrieve the IDs of users who have favorited a specific recipe
    query = """SELECT users.id FROM users
                INNER JOIN favorite ON users.id = favorite.user_id
                INNER JOIN recipes ON register.recipe_id = recipes.id
                WHERE recipes.id = %(id)s;"""
    results = connectToMySQL().query_db(query, data)
    return [result['id'] for result in results]

  @staticmethod
  def update(data):
    # Update a recipe in the database
    query = """UPDATE recipes SET
                name = %(name)s,
                description = %(description)s,
                instructions = %(instructions)s,
                created_at = %(created_at)s,
                under_30 = %(under_30)s
                WHERE id = %(id)s
    """
    return connectToMySQL().query_db(query, data)

  @classmethod
  def validate(cls, recipe):
    errors = []
    
    # Add validation logic here
    
    return errors
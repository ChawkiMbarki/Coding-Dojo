from flask import redirect, request, render_template, url_for, session, flash
from flask_app import app
from flask_app.models.user import User
from flask_app.models.recipe import Recipes

@app.route('/recipes')
def view_recipes():
  if not 'id' in session:
    return redirect(url_for('home'))
  user = User.get_user({'id': session['id']})
  recipes = Recipes.get_all()
  return render_template('recipes.html', user=user, recipes=recipes)

@app.route("/recipes/new")
def new_recipe():
  if not 'id' in session:
    return redirect(url_for('home'))
  user = User.get_user({'id': session['id']})
  return render_template("create_recipe.html", user=user)

@app.route("/recipes/create", methods=['POST'])
def create_recipe():
  errors = Recipes.validate(request.form)
  if errors:
    flash("Validation failed.")
    return redirect(url_for('new_recipe'))
  
  under_30 = 1 if request.form.get('under_30') == 'True' else 0
  
  data = {
    'name': request.form['name'],
    'description': request.form['description'],
    'instructions': request.form['instructions'],
    'created_at': request.form['created_at'],
    'under_30': under_30,
    'owner_id': session['id']
  }
  Recipes.save(data)
  return redirect(url_for('view_recipes'))

@app.route("/recipes/view/<int:id>")
def view_recipe(id):
  if not 'id' in session:
    return redirect(url_for('home'))
  user = User.get_user({'id': session['id']})
  recipe = Recipes.get_recipe({'id': id})
  return render_template('show_recipe.html', user=user, recipe=recipe)

@app.route("/recipes/edit/<int:id>")
def edit_recipe(id):
  if not 'id' in session:
    return redirect(url_for('home'))
  user = User.get_user({'id': session['id']})
  recipe = Recipes.get_recipe({'id': id})
  return render_template("edit_recipe.html", user=user, recipe=recipe)

@app.route("/recipes/edit/<int:id>/save", methods=['POST'])
def save_recipe_changes(id):
  errors = Recipes.validate(request.form)
  if errors:
    flash("Validation failed.")
    return redirect(url_for('edit_recipe', id=id))
  
  under_30 = 1 if request.form.get('under_30') == 'True' else 0
  
  data = {
    'id': id,
    'name': request.form['name'],
    'description': request.form['description'],
    'instructions': request.form['instructions'],
    'created_at': request.form['created_at'],
    'under_30': under_30
  }
  Recipes.update(data)
  return redirect(url_for('view_recipes'))

@app.route("/recipes/remove/<int:id>")
def remove_recipe(id):
  Recipes.remove({'recipe_id': id})
  return redirect(url_for('view_recipes'))

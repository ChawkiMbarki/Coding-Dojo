from flask import render_template, redirect, url_for, request
from flask_app import app
from flask_app.config.mysqlconnection import connectToMySQL
from flask_app.models.dojo import Dojo
from flask_app.models.ninja import Ninja

@app.route("/ninjas")
def create_ninja():
  dojos = Dojo.get_all()
  return render_template('create_ninja.html', dojos = dojos)

@app.route("/create_ninja", methods = ['POST'])
def new_ninja():
  ninja = request.form
  Ninja.save(request.form)
  
  return redirect(url_for('home'))
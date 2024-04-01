from flask import render_template, redirect, url_for, request
from flask_app import app
from flask_app.config.mysqlconnection import connectToMySQL
from flask_app.models.dojo import Dojo
from flask_app.models.ninja import Ninja

@app.route("/")
def root():
  return redirect(url_for('home'))

@app.route("/dojos")
def home():
  dojos = Dojo.get_all()
  return render_template("index.html", dojos = dojos)

@app.route("/create_dojo", methods = ['POST'])
def create_dojo():
  Dojo.save(request.form)
  return redirect(url_for('home'))

@app.route("/dojos/<int:id>")
def show_dojo(id):
  dojo = Dojo.get(id)
  ninjas = Ninja.dojo_ninjas(id)
  return render_template('dojo.html', dojo = dojo, ninjas = ninjas)

from flask import render_template, redirect, url_for
from flask_app import app
from flask_app.config.mysqlconnection import connectToMySQL
from flask_app.models import dojo

@app.route("/")
def root():
  return redirect(url_for('home'))

@app.route("/dojos")
def home():
  return render_template("index.html")

@app.route("/dojos/<int:id>")
def show_dojo(id):
  return render_template('dojo.html', dojo = 1) # dojo.get(id)

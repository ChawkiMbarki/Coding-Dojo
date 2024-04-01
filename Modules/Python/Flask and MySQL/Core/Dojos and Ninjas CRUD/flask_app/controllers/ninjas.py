from flask import render_template, redirect, url_for
from flask_app import app
from flask_app.config.mysqlconnection import connectToMySQL

@app.route("/ninjas")
def create_ninja():
  return render_template('create_ninja.html')

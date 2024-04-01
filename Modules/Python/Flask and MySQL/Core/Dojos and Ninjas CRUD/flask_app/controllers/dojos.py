from flask import render_template, redirect, url_for
from flask_app import app
from flask_app.config.mysqlconnection import connectToMySQL

@app.route("/")
def root():
  return redirect(url_for('home'))

@app.route("/dojos")
def home():
  return render_template("index.html")
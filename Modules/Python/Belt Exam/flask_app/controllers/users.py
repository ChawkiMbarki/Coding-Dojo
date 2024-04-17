from flask_app.models.user import User
from flask_app import app
from flask import redirect, request, render_template, url_for, session, flash
from flask_bcrypt import Bcrypt

bcrypt = Bcrypt(app)

@app.route('/')
def home():
  if('id' in session):
    return redirect(url_for('dashboard'))
  
  return render_template('index.html')

@app.route('/user/login', methods = ['POST'])
def login():
  user = User.get_by_email({"email": request.form['login_email']})
  session['id'] = user.id
  return redirect(url_for('dashboard'))

@app.route('/user/logout')
def logout():
  session.clear()
  return redirect(url_for('home'))

@app.route('/user/create', methods = ['POST'])
def new_user():
  password = bcrypt.generate_password_hash(request.form['password'])
  data = {
    'first_name' : request.form['first_name'],
    'last_name' : request.form['last_name'],
    'email' : request.form['email'],
    'password' : password
  }
  id = User.save(data)
  session['id'] = id
  return redirect(url_for('home'))

@app.route('/dashboard')
def dashboard():
  id = session['id']
  user = User.get_user({'id': id})
  return render_template('dashboard.html', user = user)

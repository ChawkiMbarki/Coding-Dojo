from flask_app.models.user import User
from flask_app import app
from flask import redirect, request, render_template, url_for, session, flash
from flask_bcrypt import Bcrypt

bcrypt = Bcrypt(app)

@app.route('/')
def home():
  if('id' in session):
    id = session['id']
    user = User.get_user({'id': id})
    return redirect(url_for('dashboard', id = id))
  return render_template('index.html')

@app.route('/user/login', methods = ['POST'])
def login():
  errors = User.validate_login(request.form)

  if(errors):
    return redirect(url_for('home'))
  user = User.get_by_email({"email": request.form['login_email']})
  if(not bcrypt.check_password_hash(user.password, request.form['login_password'])): 
            error = "Password or Email is wrong"
            errors.append(error)
            flash(error, 'error')
            return redirect(url_for('home'))

  return redirect(url_for('dashboard', id = user.id))

@app.route('/user/logout')
def logout():
  session.clear()
  return redirect(url_for('home'))

@app.route('/user/create', methods = ['POST'])
def new_user():
  errors = User.validate_registration(request.form)
  if(errors):
    return redirect(url_for('home'))
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

@app.route('/user/profile/<int:id>')
def dashboard(id):
  user = User.get_user({'id': id})
  return render_template('dashboard.html', user = user)

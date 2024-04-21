from flask_app.models.user import User
from flask_app.models.trip import Trip
from flask_app import app
from flask import redirect, request, render_template, url_for, session, flash

@app.route("/trips/new")
def new_trip():
  user = User.get_user({'id': session['id']})
  return render_template("create_trip.html", user = user)

@app.route("/trips/create", methods = ['POST'])
def create_trip():
  errors = Trip.validate(request.form)
  if(errors):
    return redirect(url_for('new_trip'))
  data = {
    'destination' : request.form['destination'],
    'start_date' : request.form['start_date'],
    'end_date' : request.form['end_date'],
    'plan' : request.form['plan'],
    'creator_id': session['id']
  }
  Trip.save(data)
  return redirect(url_for('dashboard'))

@app.route("/trips/<int:id>")
def show_trip(id):
  user = User.get_user({'id': session['id']})
  trip = Trip.get_trip({'id': id})
  creator = User(Trip.creator({'id': trip.creator_id}))
  guests_ids = Trip.guests_ids({'id': id})
  users = User.getUsersById(guests_ids)
  return render_template('trip.html', user = user, trip = trip, creator = creator, users = users)

@app.route("/trips/join/<int:id>")
def join_trip(id):
  data = {
    'user_id': session['id'],
    'trip_id': id
  }
  Trip.join(data)
  return redirect(url_for('dashboard'))

@app.route("/trips/Edit/<int:id>")
def edit_trip(id):
  user = User.get_user({'id': session['id']})
  trip = Trip.get_trip({'id': id})
  data = {
    'user_id': session['id'],
    'trip_id': id
  }
  return render_template("edit_trip.html", user = user, trip = trip)

@app.route("/trips/edit/<int:id>/success", methods = ['POST'])
def save_trip_changes(id):
  errors = Trip.validate(request.form)
  if(errors):
    return redirect(url_for('edit_trip', id = id))
  data = {
    'id': id,
    'destination' : request.form['destination'],
    'start_date' : request.form['start_date'],
    'end_date' : request.form['end_date'],
    'plan' : request.form['plan'],
    'creator_id': session['id']
  }
  Trip.update(data)
  return redirect(url_for('dashboard'))

@app.route("/trips/cancel/<int:id>")
def cancel_trip(id):
  data = {
    'user_id': session['id'],
    'trip_id': id
  }
  Trip.cancel(data)
  return redirect(url_for('dashboard'))

@app.route("/trips/remove/<int:id>")
def remove_trip(id):
  data = {
    'trip_id': id
  }
  Trip.remove(data)
  return redirect(url_for('dashboard'))
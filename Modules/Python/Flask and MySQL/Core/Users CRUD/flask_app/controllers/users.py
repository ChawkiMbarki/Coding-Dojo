from flask import render_template, request, redirect, url_for
from flask_app.models.user import User
from flask_app import app

@app.route("/")
def index():
    # call the get all classmethod to get all users
    users = User.get_all()
    return render_template("index.html", users = users)

@app.route("/show/<int:id>")
def show_user(id):
    data = {'id': id}
    user = User.get_user(data)
    return render_template("user.html", user = user)

@app.route("/create_user", methods = ["POST"])
def create_user():
    if not User.validate_user(request.form):
        # we redirect to the template with the form.
        return redirect(url_for('index'))
    return redirect(url_for('show_user', id = User.save(request.form)))

@app.route('/update',methods=['POST'])
def update():
    User.update(request.form)
    return redirect(url_for('index'))

@app.route("/delete/<int:id>")
def delete(id):
    User.delete(id)
    return redirect(url_for('index'))
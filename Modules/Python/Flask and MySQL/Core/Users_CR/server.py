from flask import Flask, render_template, redirect, request, url_for
from user import User

app = Flask(__name__)

@app.route("/")
def home():
    users = User.get_all()
    return render_template("index.html", users = users)

@app.route("/add_user")
def add_user():
    return render_template("add_user.html")

@app.route("/add_user/save", methods = ['post'])
def save_user():
    data = {
        'fname' : request.form['fname'],
        'lname' : request.form['lname'],
        'email' : request.form['email']
    }
    print(data)
    User.save(data)
    return redirect(url_for('home'))

if __name__ == "__main__":
    app.run(debug = True)
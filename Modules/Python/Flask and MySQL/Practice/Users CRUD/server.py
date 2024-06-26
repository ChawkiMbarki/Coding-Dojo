from flask import Flask, render_template, request, redirect, url_for
# import the class from User.py
from user import User
app = Flask(__name__)
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
    data = {
        'fname': request.form["fname"],
        'lname': request.form["lname"],
        'email': request.form["email"]
    }

    return redirect(url_for('show_user', id = User.save(data)))

@app.route('/update',methods=['POST'])
def update():
    User.update(request.form)
    return redirect('/')

@app.route("/delete/<int:id>")
def delete(id):
    User.delete(id)
    return redirect("/")

if __name__ == "__main__":
    app.run(debug=True)
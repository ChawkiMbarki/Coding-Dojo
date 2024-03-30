from flask import Flask, render_template, request, redirect, url_for
# import the class from User.py
from user import User
app = Flask(__name__)
@app.route("/")
def index():
    # call the get all classmethod to get all users
    users = User.get_all()
    return render_template("index.html", users = users)

@app.route("/create_user", methods = ["POST"])
def create_user():
    data = {
        'fname': request.form["fname"],
        'lname': request.form["lname"],
        'occ': request.form["occ"]
    }
    User.save(data)
    return redirect("/")

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
from flask import Flask, render_template, request, redirect, url_for
# import the class from friend.py
from friend import Friend
app = Flask(__name__)
@app.route("/")
def index():
    # call the get all classmethod to get all friends
    friends = Friend.get_all()
    return render_template("index.html", friends = friends)

@app.route("/create_friend", methods = ["POST"])
def create_friend():
    data = {
        'fname': request.form["fname"],
        'lname': request.form["lname"],
        'occ': request.form["occ"]
    }
    Friend.save(data)
    return redirect("/")

@app.route('/update',methods=['POST'])
def update():
    Friend.update(request.form)
    return redirect('/')

@app.route("/delete/<int:id>")
def delete(id):
    Friend.delete(id)
    return redirect("/")

if __name__ == "__main__":
    app.run(debug=True)
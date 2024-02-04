from flask import Flask, render_template

app = Flask(__name__)

@app.route("/")
def home():
    return render_template("index.html")

@app.route("/play")
def play():
    return render_template("play.html", x = 3, color = "blue")

@app.route("/play/<int:x>")
def play2(x):
    return render_template("play.html", x = x, color = "blue")

@app.route("/play/<int:x>/<color>")
def play3(x, color):
    return render_template("play.html", x = x, color = color)

app.run(debug = True)
from flask import Flask, render_template, request, session, redirect

app = Flask(__name__)

app.secret_key = 'qsdAxcv1235SQDF12343d54'

@app.route("/")
def home():
    if 'count' in session:
        session["count"] += 1
    else :
        session["count"] = 1
    return render_template("index.html", count = session["count"])

@app.route("/increment", methods = ['POST'])
def increment():
    if 'count' in session:
        session["count"] += 1
    else :
        session["count"] = 1
    return redirect("/")

@app.route("/destroy_session", methods = ['POST'])
def destroy_session():
    del session['count']
    return redirect("/")

if __name__ == "__main__" :
    app.run(debug = True)
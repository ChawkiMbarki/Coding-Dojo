from flask import Flask, redirect, render_template, request, session, url_for
import os

app = Flask(__name__)

app.secret_key = os.urandom(24)

class user:
    def __init__(self, name, dojo_location, fav_lang, comment):
        user.name = name
        user.dojo_location = dojo_location
        user.fav_lang = fav_lang
        user.comment = comment

    def to_json(self):
        json_user = {
            'name': self.name,
            'dojo_location': self.dojo_location,
            'fav_lang': self.fav_lang,
            'comment': self.comment,
        }
        print(json_user['dojo_location'])
        return json_user

@app.route("/")
def home():
    if 'user' in session:
        return redirect('/result')
    return render_template('index.html')

@app.route("/result")
def result():
    if 'user' in session:
        user = session['user']
        return render_template('result.html', user = user)
    return redirect(url_for('home'))

@app.route("/process", methods=['POST'])
def process():
    name = request.form.get('name')
    dojo_location = request.form.get('dojo_location')
    fav_lang = request.form.get('fav_lang')
    comment = request.form.get('cmnt')

    session['user'] = user(name, dojo_location, fav_lang, comment).to_json()

    return redirect(url_for('result'))

@app.route("/log_out")
def log_out():
    if 'user' in session:
        session.pop('user')
    return redirect(url_for('home'))

if __name__ == "__main__":
    app.run(debug = True)
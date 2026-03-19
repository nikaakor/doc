from flask import Flask, render_template, request, redirect
from services.film_service import get_all_films, add_film, delete_film, get_film_by_id, update_film
from datetime import date

app = Flask(__name__)

@app.route("/")
def index():
    search_query = request.args.get('search')
    films = get_all_films(search_query)
    return render_template("index.html", films=films)

@app.route("/create", methods=["GET", "POST"])
def create():
    if request.method == "POST":
        add_film(
            request.form["title"], 
            request.form["category"], 
            request.form["year"], 
            request.form["rating"],
            request.form["image_url"] 
        )
        return redirect("/")
    return render_template("create.html", film=None)

@app.route("/edit/<int:id>", methods=["GET", "POST"])
def edit(id):
    film = get_film_by_id(id)
    if film is None:
        return "Film not found", 404
        
    if request.method == "POST":
        update_film(
            id, 
            request.form["title"], 
            request.form["category"], 
            request.form["year"], 
            request.form["rating"],
            request.form["image_url"]
        )
        return redirect("/")
    return render_template("create.html", film=film)

@app.route("/delete/<int:id>")
def delete(id):
    delete_film(id)
    return redirect("/")

if __name__ == "__main__":
    app.run(debug=True)
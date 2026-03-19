from models.film import Film

films = [
    Film(1, 
         "Spider-Man: No Way Home", 
         "Action/Sci-Fi", 
         2021, 
         8.2, 
         "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/uJ9L3Y48vS37N739uC9f8t3YKEj.jpg"),
    
    Film(2, 
         "Spider-Man: Into the Spider-Verse", 
         "Animation/Action", 
         2018, 
         8.4, 
         "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/iiZZdoBmBvYq797XS98OR7v9S86.jpg"),
    
    Film(3, 
         "Spider-Man: Across the Spider-Verse", 
         "Animation/Action", 
         2023, 
         8.6, 
         "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8VtW9S9VpSV88STh89498t3mXas.jpg"),
         
    Film(4, 
         "Spider-Man (2002)", 
         "Action/Adventure", 
         2002, 
         7.4, 
         "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/ghO9YnAlWpSSt899SB9o88v869H.jpg"),
         
    Film(5, 
         "The Amazing Spider-Man", 
         "Action/Adventure", 
         2012, 
         7.0, 
         "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/j73S1S3UaYmS6mS5p977noZpS6S.jpg")
]

def get_all_films(search_query=None):
    if search_query:
        return [f for f in films if search_query.lower() in f.title.lower() or search_query.lower() in f.category.lower()]
    return films

def get_film_by_id(id):
    return next((f for f in films if f.id == id), None)

def add_film(title, category, year, rating, image_url):
    new_id = max([f.id for f in films], default=0) + 1
    if not image_url:
        image_url = "https://via.placeholder.com/500x750?text=No+Poster"
    new_film = Film(new_id, title, category, int(year), float(rating), image_url)
    films.append(new_film)

def delete_film(id):
    global films
    films = [f for f in films if f.id != id]

def update_film(id, title, category, year, rating, image_url):
    film = get_film_by_id(id)
    if film:
        film.title = title
        film.category = category
        film.year = int(year)
        film.rating = float(rating)
        if image_url:
            film.image_url = image_url
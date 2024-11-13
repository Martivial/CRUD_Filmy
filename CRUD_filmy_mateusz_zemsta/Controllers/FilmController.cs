using Microsoft.AspNetCore.Mvc;
using CRUD_filmy_mateusz_zemsta.Models;
using System.Collections.Generic;
using System.Linq;


namespace CRUD_filmy_mateusz_zemsta.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film { Id = 1, Name = "Film1", Description = "opis filmu1", Price = 3 },
            new Film { Id = 2, Name = "Film2", Description = "opis filmu2", Price = 5 },
            new Film { Id = 3, Name = "Film3", Description = "opis filmu3", Price = 3 }
        };

        // GET: Film
        public IActionResult Index()
        {
            return View(films);
        }

        // GET: Film/Details/5
        public IActionResult Details(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null) return NotFound();
            return View(film);
        }

        // GET: Film/Create
        public IActionResult Create()
        {
            return View(new Film());
        }

        // POST: Film/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Film film)
        {
            film.Id = films.Count + 1; // Generowanie unikalnego ID
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

        // GET: Film/Edit/5
        public IActionResult Edit(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null) return NotFound();
            return View(film);
        }

        // POST: Film/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Film updatedFilm)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null) return NotFound();

            film.Name = updatedFilm.Name;
            film.Description = updatedFilm.Description;
            film.Price = updatedFilm.Price;

            return RedirectToAction(nameof(Index));
        }

        // GET: Film/Delete/5
        public IActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null) return NotFound();
            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film != null)
            {
                films.Remove(film);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

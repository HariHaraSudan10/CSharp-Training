using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment1___Question2.Models;
using Assessment1___Question2.Repository;

namespace Assessment1___Question2.Controllers
{
    public class MovieController : Controller
    {
        MovieRepository repo = new MovieRepository();
        // GET: Movie
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Create(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult MoviesByYear(int year)
        {
            return View(repo.GetMoviesByYear(year));
        }

        [HttpPost]
        public ActionResult MoviesByDirector(string director)
        {
            return View(repo.GetMoviesByDirector(director));
        }
    }
}
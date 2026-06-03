using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assessment1___Question2.Models;
using System.Data.Entity;


namespace Assessment1___Question2.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieContext db = new MovieContext();

        public List<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public void Create(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie)
        {
            var m = db.Movies.Find(movie.Mid);

            m.Moviename = movie.Moviename;
            m.DirectorName = movie.DirectorName;
            m.DateofRelease = movie.DateofRelease;

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var m = db.Movies.Find(id);
            db.Movies.Remove(m);
            db.SaveChanges();
        }

        public List<Movie> GetMoviesByYear(int year)
        {
            return db.Movies.Where(m => m.DateofRelease.Year == year).ToList();
        }

        public List<Movie> GetMoviesByDirector(string director)
        {
            return db.Movies.Where(m => m.DirectorName == director).ToList();
        }
    }
}
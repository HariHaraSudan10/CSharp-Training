using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assessment1___Question2.Models;

namespace Assessment1___Question2.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();

        void Create(Movie movie);

        void Update(Movie movie);

        void Delete(int id);

        List<Movie> GetMoviesByYear(int year);

        List<Movie> GetMoviesByDirector(string director);
    }
}
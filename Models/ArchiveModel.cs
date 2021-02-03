using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_3.Models
{
    public static class ArchiveModel
    {
        //making a list and instatiationg the list
        private static List<NewMovieModel> aMovies = new List<NewMovieModel>();


        //lambda is basically doing AMovies(aMovies)
        public static IEnumerable<NewMovieModel> AMovies => aMovies;

        public static void AddMovie(NewMovieModel movie)
        {
            //adding a movie to the list aMovies
            aMovies.Add(movie);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_3.Models
{
    public static class ArchiveModel
    {
        //making a list and instatiationg the list. an object that stores a lot of information
        //type of the list is a new movie 
        private static List<NewMovieModel> aMovies = new List<NewMovieModel>();


        //lambda is basically doing AMovies(aMovies)
        //IEnumerable is allows to iterate through the list
        public static IEnumerable<NewMovieModel> AMovies => aMovies;

        //pass newmoviemodel type and you're going to add a new movie
        public static void AddMovie(NewMovieModel movie)
        {
            //adding a movie to the list aMovies
            aMovies.Add(movie);
        }
    }
}

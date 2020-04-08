using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmalltownCinemas.DAL;
using SmalltownCinemas.Models;
using System.Collections.Generic;

namespace SmalltownCinemaTests
{
    [TestClass]
    public class MovieSqlDAOTests
    {
        private const string connString = "Server=.\\SQLExpress; Database=SmallTownCinema; Trusted_Connection=True;";
        IMovieDAO movieDAO = new MovieSqlDAO(connString);

        [TestMethod]
        public void GetAllMoviesTest()
        {
            IList<Movie> movies = movieDAO.GetAllMovies();
            int actual = movies.Count;
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void GetMovieByIdTest()
        {
            int id = 1;
            Movie movie = movieDAO.GetMovieById(id);
            Assert.IsNotNull(movie);
        }
    }

    
}

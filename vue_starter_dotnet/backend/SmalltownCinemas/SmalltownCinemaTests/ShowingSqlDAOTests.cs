using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmalltownCinemas.DAL;
using SmalltownCinemas.Models;
using System.Collections.Generic;

namespace SmalltownCinemaTests
{
    [TestClass]
    public class ShowingSqlDAOTests
    {
        private const string connString = "Server=.\\SQLExpress; Database=SmallTownCinema; Trusted_Connection=True;";
        IShowingDAO showingDAO = new ShowingSqlDAO(connString);


        [TestMethod]
        public void GetAllShowingsTest()
        {
            IList<Showing> showings = showingDAO.GetAllShowings();
            int actual = showings.Count;
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void GetShowingsByMovieId()
        {
            IList<Showing> showings = showingDAO.GetShowingsByMovieId(1);
            int actual = showings.Count;
            Assert.IsTrue(actual > 0);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmalltownCinemas.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmalltownCinemaTests
{ 
    [TestClass]
    public class UserSwlDAOTests
    {
        private const string connString = "Server=.\\SQLExpress; Database=SmallTownCinema; Trusted_Connection=True;";
        IUserDAO userDAO = new UserSqlDAO(connString);

        [TestMethod]
        public void GetEmailByUserTest()
        {
            userDAO.GetEmailByUser("");

        }
    }
}

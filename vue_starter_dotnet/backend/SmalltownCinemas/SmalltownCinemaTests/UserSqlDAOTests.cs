using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmalltownCinemas.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmalltownCinemaTests
{ 
    [TestClass]
    public class UserSqlDAOTests
    {
        private const string connString = "Server=.\\SQLExpress; Database=SmallTownCinema; Trusted_Connection=True;";
        IUserDAO userDAO = new UserSqlDAO(connString);

        [TestMethod]
        public void GetEmailByUserTest()
        {
            int userId = 0;
            userId = userDAO.GetUserIdByEmailAddress("a@b.com");
            Assert.IsTrue(userId != 0);
        }
    }
}

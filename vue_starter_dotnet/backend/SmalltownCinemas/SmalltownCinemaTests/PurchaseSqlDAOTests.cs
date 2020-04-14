﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmalltownCinemas.DAL;
using SmalltownCinemas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmalltownCinemaTests
{
    [TestClass]
    public class PurchaseSqlDAOTests
    {
        private const string connString = "Server=.\\SQLExpress; Database=SmallTownCinema; Trusted_Connection=True;";
        IPurchaseDAO purchaseDAO = new PurchaseSqlDAO(connString);

        [TestMethod]
        public void GetReservedSeatsByShowingIdTest()
        {
            List<Ticket> tickets = purchaseDAO.GetReservedSeatsByShowingId(256);
            int actual = tickets.Count;
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void GetReservedSeatsTest()
        {
            List<Ticket> tickets = purchaseDAO.GetReservedSeats(1,"2020-04-15","10:00");
            int actual = tickets.Count;
            Assert.AreEqual(4, actual);
        }
    }
}

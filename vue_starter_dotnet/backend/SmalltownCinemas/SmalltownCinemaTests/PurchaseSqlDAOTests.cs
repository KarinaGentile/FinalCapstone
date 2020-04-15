using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void CreateNewPurchaseTest()
        {
            Purchase purchase = purchaseDAO.CreateNewPurchase(3.14);
            Assert.IsNotNull(purchase.PurchaseId);
        }


        [TestMethod]
        public void CreateNewTicketsTest()
        {
            List<string> seatNumbers = new List<string>();
            seatNumbers.Add("A2");
            seatNumbers.Add("A3");
            seatNumbers.Add("A4");
            seatNumbers.Add("A5");
            seatNumbers.Add("B1");
            seatNumbers.Add("B2");
            seatNumbers.Add("B3");
            seatNumbers.Add("B4");
            int actual = purchaseDAO.CreateNewTickets(4, 18, seatNumbers, 5);
            int expected = seatNumbers.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}

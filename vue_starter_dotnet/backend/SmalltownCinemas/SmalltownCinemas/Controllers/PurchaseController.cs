using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmalltownCinemas.DAL;
using SmalltownCinemas.Models;

namespace SmalltownCinemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private IPurchaseDAO purchaseDAO;
        private IUserDAO userDAO;
        private IShowingDAO showingDAO;

        public PurchaseController(IPurchaseDAO purchase, IUserDAO user, IShowingDAO showing)
        {
            this.purchaseDAO = purchase;
            this.userDAO = user;
            this.showingDAO = showing;
        }


        // make a new purchase
        //  need what inputs? 
        //      purchases table: user id, total price
        //      tickets table: showing id, seat it, purchase id

        // get all reserved seats for a given showing
        //  input showing id
        //  get back a 
        [HttpGet("showing/{showingId}")]
        public IActionResult GetReservedSeatsByShowingId(int showingId)
        {
            return new JsonResult(purchaseDAO.GetReservedSeatsByShowingId(showingId));
        }

        [HttpGet("{movieId}/{date}/{startTime}")]
        public IActionResult GetReservedSeats(int movieId, string date, string startTime)
        {
            List<Ticket> tickets = purchaseDAO.GetReservedSeats(movieId, date, startTime);
            List<string> seats = new List<string>();
            foreach (var t in tickets)
            {
                seats.Add(t.SeatName);
            }
            return new JsonResult(seats);
        }

        [HttpGet("new/{email}/{price}/{seatStr}/{movieId}/{date}/{startTime}")]
        public IActionResult ExecutePurchase(string email, string price, string seatStr, int movieId, string date, string startTime)
        {
            int userId = userDAO.GetUserIdByEmailAddress(email);
            double priceTotal = Convert.ToDouble(price);
            if (seatStr[seatStr.Length - 1] == '-')
            {
                seatStr = seatStr.Substring(0, seatStr.Length - 1);
            }
            List<string> seats = new List<string>();
            seats.AddRange(seatStr.Split('-'));
            Purchase purchase = purchaseDAO.CreateNewPurchase(priceTotal, userId);
            int showingId = showingDAO.GetShowingId(movieId, date, startTime);
            int numTickets = purchaseDAO.CreateNewTickets(purchase.PurchaseId, showingId, seats, priceTotal);
            return new JsonResult(new { purchase, numTickets});
        }

        [HttpGet("lookup/{purchaseId}")]
        public IActionResult ReceiptLookup(int purchaseId)
        {
            Receipt receipt = purchaseDAO.GetPurchaseInfoForReceipt(purchaseId);
            return new JsonResult(receipt);
        }

    }
}
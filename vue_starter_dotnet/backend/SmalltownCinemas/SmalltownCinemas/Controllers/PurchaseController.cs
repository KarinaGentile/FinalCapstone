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

        public PurchaseController(IPurchaseDAO purchase, IUserDAO user)
        {
            this.purchaseDAO = purchase;
            this.userDAO = user;
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

        [HttpGet("{email}/{price}")]
        public IActionResult ExecutePurchase(string email, string price)
        {
            int userId = userDAO.GetUserIdByEmailAddress(email);
            double priceTotal = Convert.ToDouble(price);
            Purchase purchase = purchaseDAO.CreateNewPurchase(priceTotal, userId);
            return new JsonResult(purchase);
        }
        
    }
}
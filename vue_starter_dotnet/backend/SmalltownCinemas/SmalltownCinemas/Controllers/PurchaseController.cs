﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmalltownCinemas.DAL;

namespace SmalltownCinemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private IPurchaseDAO purchaseDAO;

        public PurchaseController(IPurchaseDAO purchase)
        {
            this.purchaseDAO = purchase;
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
    }
}
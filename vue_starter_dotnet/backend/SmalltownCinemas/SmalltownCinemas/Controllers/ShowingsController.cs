using System;
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
    public class ShowingsController : ControllerBase
    {
        private IShowingDAO showingDAO;

        public ShowingsController(IShowingDAO showingDAO)
        {
            this.showingDAO = showingDAO;
        }

        [HttpGet]
        public IActionResult GetAllShowings()
        {
            return new JsonResult(showingDAO.GetAllShowings());
        }

        [HttpGet("{movieId}")]
        public IActionResult GetAllShowingsByMovieId(int movieId)
        {
            return new JsonResult(showingDAO.GetShowingsByMovieId(movieId));
        }

        [HttpGet("{movieId}/{date}")]
        public IActionResult GetAllShowingsByMovieId(int movieId, string date)
        {
            return new JsonResult(showingDAO.GetShowingsByMovieId(movieId, date));
        }
    }
}

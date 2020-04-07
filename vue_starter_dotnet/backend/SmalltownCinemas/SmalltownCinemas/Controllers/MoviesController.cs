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
    public class MoviesController : ControllerBase
    {
        private IMovieDAO movieDAO;
        private IShowingDAO showingDAO;

        public MoviesController(IMovieDAO movieDAO, IShowingDAO showingDAO)
        {
            this.movieDAO = movieDAO;
            this.showingDAO = showingDAO;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return new JsonResult(movieDAO.GetAllMovies());
        }

        [HttpGet("showings")]
        public IActionResult GetAllShowings()
        {
            return new JsonResult(showingDAO.GetAllShowings());
        }
    }
}
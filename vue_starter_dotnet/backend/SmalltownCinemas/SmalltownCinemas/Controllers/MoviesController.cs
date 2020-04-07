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


        public MoviesController(IMovieDAO movieDAO)
        {
            this.movieDAO = movieDAO;
<<<<<<< HEAD
=======
            
        }
>>>>>>> b39f54f9f8d8b08e0f7aa6d039864f3dfd24ee2f

        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return new JsonResult(movieDAO.GetAllMovies());
        }

<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
        [HttpGet("showings")]
        public IActionResult GetAllShowings()
        {
            return new JsonResult(showingDAO.GetAllShowings());
        }
>>>>>>> dd722565134a70ddf1a1fc19d45eb466879ddede
>>>>>>> b39f54f9f8d8b08e0f7aa6d039864f3dfd24ee2f
    }
}
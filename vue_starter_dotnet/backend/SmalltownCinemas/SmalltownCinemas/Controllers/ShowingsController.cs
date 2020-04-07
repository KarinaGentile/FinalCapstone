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
<<<<<<< HEAD
    }
}
=======



    }
}
>>>>>>> b39f54f9f8d8b08e0f7aa6d039864f3dfd24ee2f

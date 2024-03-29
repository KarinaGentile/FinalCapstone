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
    public class MoviesController : ControllerBase
    {
        private IMovieDAO movieDAO;


        public MoviesController(IMovieDAO movieDAO)
        {
            this.movieDAO = movieDAO;

        }


        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return new JsonResult(movieDAO.GetAllMovies());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            return new JsonResult(movieDAO.GetMovieById(id));
        }

    }
}
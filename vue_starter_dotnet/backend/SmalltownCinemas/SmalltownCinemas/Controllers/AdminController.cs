using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmalltownCinemas.Models;

namespace SmalltownCinemas.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public string BaseURL { get; set; } = "https://www.omdbapi.com/?";
        public string ApiKey { get; } = "apikey=42acd889";

        [HttpGet("{id}")]
        public IActionResult GetAndStoreMovieById(string id)
        {
            WebRequest requestObj = WebRequest.Create($"{BaseURL}i={id}&{ApiKey}");
            requestObj.Method = "GET";
            HttpWebResponse responseObj = null;
            responseObj = (HttpWebResponse)requestObj.GetResponse();

            string result = null;
            using (Stream stream = responseObj.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                result = sr.ReadToEnd();
            }

            Movie movie = new Movie();
            movie = JsonConvert.DeserializeObject<Movie>(result);
            return new JsonResult(movie);
        }
    }
}
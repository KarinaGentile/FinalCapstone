﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmalltownCinemas.Models
{
    /// <summary>
    /// A movie object
    /// </summary>
    public class Movie
    {
        public Movie()
        {

        }

        public Movie(int movieId,string title, string rating, string plot, string cast, int runtime, string imdbId, string posterURL)
        {
            this.Title = title;
            this.Rating = rating;
            this.Plot = plot;
            this.RuntimeInMinutes = runtime;
            this.IMDBId = imdbId;
            string[] actors = cast.Split(',');
            List<string> cst = new List<string>();
            foreach (string a in actors)
            {
                cst.Add(a.Trim());
            }
            this.Cast = cst;
            this.MovieId = movieId;
            this.PosterURL = posterURL;
        }

        /// <summary>
        /// The id of the movie in the SQL database
        /// </summary>
        public int MovieId { get; private set; }

        /// <summary>
        /// The title of the movie
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// The movie's MPAA rating
        /// </summary>
        public string Rating { get; private set; }

        /// <summary>
        /// A summary of the movie's plot
        /// </summary>
        public string Plot { get; private set; }

        /// <summary>
        /// A list containing the names of the top-billed actors/actresses
        /// </summary>
        public List<string> Cast { get; private set; }

        /// <summary>
        /// The movie's runtime in minutes
        /// </summary>
        public int RuntimeInMinutes { get; private set; }

        /// <summary>
        /// The IMDB id of the movie
        /// </summary>
        public string IMDBId { get; private set; }

        /// <summary>
        /// The URL of the poster image
        /// </summary>
        public string PosterURL { get; private set; }

    }
}

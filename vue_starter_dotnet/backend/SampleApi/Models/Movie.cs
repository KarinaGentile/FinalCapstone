using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// A movie object
    /// </summary>
    public class Movie
    {
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

    }
}

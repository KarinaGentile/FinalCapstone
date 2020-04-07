using SmalltownCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmalltownCinemas.DAL
{
    public interface IShowingDAO
    {
        IList<Showing> GetAllShowings();

        IList<Showing> GetShowingsByMovieId(int movieId);


    }
}

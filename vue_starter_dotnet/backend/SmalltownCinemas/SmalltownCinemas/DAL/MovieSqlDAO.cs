using SmalltownCinemas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SmalltownCinemas.DAL
{
    public class MovieSqlDAO : IMovieDAO
    {
        private readonly string connectionString;

        public MovieSqlDAO(string connString)
        {
            this.connectionString = connString;
        }

        public IList<Movie> GetAllMovies()
        {
            IList<Movie> movies = new List<Movie>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM MOVIES";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        movies.Add(RowToMovie(rdr));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return movies;
        }

        private Movie RowToMovie(SqlDataReader rdr)
        {
            Movie movie = new Movie(
                Convert.ToInt32(rdr["movieid"]),
                Convert.ToString(rdr["title"]), 
                Convert.ToString(rdr["rating"]), 
                Convert.ToString(rdr["plot"]), 
                Convert.ToString(rdr["cast"]), 
                Convert.ToInt32(rdr["runtime"]), 
                Convert.ToString(rdr["imdbid"]),
                Convert.ToString(rdr["posterurl"]),
                Convert.ToString(rdr["genre"])
                );
            
            return movie;
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }


        
    }
}

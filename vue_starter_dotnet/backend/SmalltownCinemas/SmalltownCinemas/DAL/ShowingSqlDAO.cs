using SmalltownCinemas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SmalltownCinemas.DAL
{
    public class ShowingSqlDAO : IShowingDAO
    {
        private readonly string connectionString;
        public ShowingSqlDAO(string connString)
        {
            this.connectionString = connString;
        }

        public IList<Showing> GetAllShowings()
        {
            IList<Showing> showings = new List<Showing>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    string sql = "SELECT * FROM SHOWINGS WHERE starttime > @currentTime";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@currentTime", DateTime.Now);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        showings.Add(RowToShowing(rdr));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return showings;
        }

        private Showing RowToShowing(SqlDataReader rdr)
        {
            Showing showing = new Showing();
            showing.ShowingId = Convert.ToInt32(rdr["ShowingId"]);
            showing.MovieId = Convert.ToInt32(rdr["MovieId"]);
            showing.TheaterId = Convert.ToInt32(rdr["TheaterId"]);
            showing.StartTime = Convert.ToDateTime(rdr["StartTime"]);
            showing.StartTimeFormatted = showing.StartTime.ToShortTimeString();
            showing.EndTime = Convert.ToDateTime(rdr["EndTime"]);
            //showing.ShowingId = Convert.ToInt32(rdr["ShowingId"]);
            return showing;
        }

        public IList<Showing> GetShowingsByMovieId(int movieId, string date = "2020-04-09")
        {

            IList<Showing> showings = new List<Showing>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    string sql = @"
select * from Showings 
where MovieId = @id 
and starttime > @currentTime 
and (convert(date,starttime)) = @selectedDate";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", movieId);
                    cmd.Parameters.AddWithValue("@currentTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@selectedDate", date);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        showings.Add(RowToShowing(rdr));
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return showings;
        }
    }
}

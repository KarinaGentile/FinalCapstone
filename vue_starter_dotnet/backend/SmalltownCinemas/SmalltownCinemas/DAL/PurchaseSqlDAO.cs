using SmalltownCinemas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SmalltownCinemas.DAL
{
    public class PurchaseSqlDAO : IPurchaseDAO
    {
        private readonly string connectionString;
        public PurchaseSqlDAO(string connString)
        {
            this.connectionString = connString;
        }

        public List<Ticket> GetReservedSeats(int movieId, string date, string startTime)
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string sql = @"select * 
                                from tickets t 
                                join showings s on t.ShowingId = s.ShowingId
                                where s.MovieId = @movieId
                                and s.StartTime = concat(@date,' ',@startTime)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@movieId", movieId);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@startTime", startTime);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tickets.Add(RowToTicket(rdr));
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }


            return tickets;
        }

        public List<Ticket> GetReservedSeatsByShowingId(int showingId)
        {
            List<Ticket> tickets = new List<Ticket>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string sql = "select * from tickets";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //add with params

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tickets.Add(RowToTicket(rdr));
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }


            return tickets;
        }

        private Ticket RowToTicket(SqlDataReader rdr)
        {
            Ticket ticket = new Ticket();
            ticket.TicketId = Convert.ToInt32(rdr["TicketId"]);
            ticket.ShowingId = Convert.ToInt32(rdr["ShowingId"]);
            ticket.SeatName = Convert.ToString(rdr["SeatName"]);
            ticket.PurchaseId = Convert.ToInt32(rdr["PurchaseId"]);
            ticket.Price = Convert.ToDouble(rdr["Price"]);
            return ticket;
        }
    }
}

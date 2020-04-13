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

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

        

        public void AdminSetupPurchasesAndTickets()
        {
            throw new NotImplementedException();
        }

        public Purchase CreateNewPurchase(double totalPrice, int userId = 1)
        {
            Purchase purchase = new Purchase();
            purchase.UserId = userId;
            purchase.DateTime = DateTime.Now;
            purchase.TotalPrice = totalPrice;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"insert into Purchases
                                (UserId,DateTime,Total_Price)
                                values
                                (1,GETDATE(),@tPrice)
                                select @@identity";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tPrice", purchase.TotalPrice);
                    purchase.PurchaseId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                return purchase;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CreateNewTickets(int purchaseId, int showingId, List<string> seatNumbers, double price)
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"insert into tickets
                                    (ShowingId, SeatName, PurchaseId, Price)
                                    values ";
                    for (int i = 0; i < seatNumbers.Count; i++)
                    {
                        sql += $"(@showingId, @seat{i}, @purchaseId, @price)";
                        if (i < seatNumbers.Count - 1)
                        {
                            sql += ",";
                        }
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@purchaseId", purchaseId);
                    cmd.Parameters.AddWithValue("@showingId", showingId);
                    cmd.Parameters.AddWithValue("@price", price);
                    for (int i = 0; i < seatNumbers.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@seat{i}",seatNumbers[i]);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
            catch (Exception)
            {

                throw;
            }
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

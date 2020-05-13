using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class DAL
    {
        SqlConnection conn;

        public DAL(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }

        // ********************** Tickets ***************************
        public IEnumerable<Ticket> GetAllTickets()
        {
            string queryString = "SELECT * FROM Tickets";
            IEnumerable<Ticket> Tickets = conn.Query<Ticket>(queryString);

            return Tickets;
        
        }

        internal Ticket GetTicket(int id)
        {
            string command = "SELECT * FROM Tickets WHERE TicketID=@id";

            Ticket result = conn.QueryFirst<Ticket>(command, new { id = id });

            conn.Close();
            return result;
        }

        internal IEnumerable<string> GetCategories()
        {
            string command = "SELECT DISTINCT Category FROM Tickets";

            IEnumerable<string> result = conn.Query<string>(command);

            conn.Close();

            return result;
        }

        public int AddTicket(Ticket t)
        {
            string queryString = "INSERT INTO Tickets (UserID, Title, Category, TicketDetail, OpenedBy, TicketStatus) VALUES(@UserID, @Title, @Category, @TicketDetail, @OpenedBy, @TicketStatus)";
            
            return conn.Execute(queryString, t);

        }

        internal IEnumerable<Ticket> GetByCategory(string cat)
        {
            string command = "SELECT * FROM Tickets WHERE Category=@category";

            IEnumerable<Ticket> result = conn.Query<Ticket>(command,
                new { category = cat });

            conn.Close();

            return result;
        }

        internal int UpdateTicket(Ticket t)
        {
            
            string command = "UPDATE Tickets SET TicketStatus='1', Resolution=@resolution, ";
            command += "ResolvedBy=@resolvedBy WHERE TicketID=@ticketID";
            return conn.Execute(command, new
            {
                resolution = t.Resolution,
                ticketID = t.TicketID,
                resolvedBy = t.ResolvedBy
            }) ;
        }

        // ********************** Favorites ***************************
        public IEnumerable<Favorite> GetAllFavorites(int id)
        {
            string queryString = "SELECT * FROM Favorites WHERE UserID = @id";
            IEnumerable<Favorite> Favorites = conn.Query<Favorite>(queryString, new { id = id});
            return Favorites;
        }

        public int AddToFavorites(Favorite f)
        {
            string query = "INSERT INTO Favorites (UserID, TicketID) VALUES (@userID, @ticketID)";

            int result = conn.Execute(query, new { userID = f.UserID, ticketID = f.TicketID});
            return result;
        }

        

        public int DeleteFavoriteByID(int id)
        {
            string delete = "DELETE FROM Favorites WHERE ID = @id";
            return conn.Execute(delete, new { id = id });
        }


        public IEnumerable<JoinedItem> AllFavorites(int id)
        {
            string command = "SELECT f.TicketID, f.UserID, t.Title FROM ";
            command += "Favorites f INNER JOIN Tickets t ON f.TicketID = t.TicketID WHERE f.UserID=@id";

            IEnumerable<JoinedItem> result = conn.Query<JoinedItem>(command,
                new { id = id });

            conn.Close();

            return result;

        }
        
    }
}

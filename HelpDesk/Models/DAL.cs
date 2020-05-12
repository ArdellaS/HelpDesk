﻿using Dapper;
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

        // ********************** Favorites ***************************
        public IEnumerable<Favorite> GetAllFavorites()
        {
            string queryString = "SELECT * FROM Favorites";
            IEnumerable<Favorite> Favorites = conn.Query<Favorite>(queryString);
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
    }
}

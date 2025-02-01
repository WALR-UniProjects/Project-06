using System;
using System.Data.SqlClient;

namespace GPM
{
    internal class DatabaseConnection
    {
        private SqlConnection connection;

        public DatabaseConnection()
        {
            string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS;Database=gpmdb;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}

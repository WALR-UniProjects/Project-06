using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GPM
{
    internal class DatabaseConnection
    {
        private MySqlConnection connection;

        public DatabaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Database=gpmdb;Uid=root;Pwd=78563;";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;

        }
    }
}

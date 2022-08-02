using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionDB : IDisposable
    {
        public readonly SqlConnection connection;

        public ConnectionDB()
        {
            string connectionString = ConfigurationManager.AppSettings["db:stringConnection"].ToString();

            connection = new SqlConnection(connectionString);
        }

        public void Open() => connection.Open();

        public void Close()
        {
            if (connection != null)
                connection.Close();
        }

        public void Dispose()
        {
            if (connection != null)
                connection.Close();
        }
    }
}

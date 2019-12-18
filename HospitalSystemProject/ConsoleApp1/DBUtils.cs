using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "parsing";
            string username = "root";
            string password = "Asdasdasd123";
            
            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sensors.Dal
{
    internal static class AgentDal
    {
         static string connectKey = "server=localhost;user=root;password=;database=Sensors";
         static MySqlCommand cmd;
         static MySqlDataReader reader;
        static MySqlConnection connection;

        private static void OpenConnection()
        {
            connection = new MySqlConnection(connectKey);
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed) connection.Open();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private static void CloseConnection()
        {
            connection = new MySqlConnection(connectKey);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //public 


    }
}

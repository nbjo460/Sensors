using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Sensors.BaseModels;

namespace Sensors.Dal
{
    internal static class AgentDal
    {
         static string connectKey = "server=localhost;user=root;password=;database=Sensors";
         static MySqlCommand cmd;
         static MySqlDataReader reader;
        static MySqlConnection connection;

        private static MySqlConnection OpenConnection()
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
            return connection;
        }
        private static void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open || connection.State == System.Data.ConnectionState.Broken)
                { 
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void InsertIranAgent(IranAgent _agent)
        {
            var connection = OpenConnection();
            string query = "INSERT INTO `AGENTS` (Id, Rank, Turns, IsExposed) " +
                $"VALUES (@id, @rank, @turns, @exposed)";
            try
            {
                cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("id", _agent.ID);
                cmd.Parameters.AddWithValue("rank", _agent.Rank);
                cmd.Parameters.AddWithValue("turns", _agent.AgentTurn.CounterTurns);
                cmd.Parameters.AddWithValue("exposed", !_agent.IsHiding);

                cmd.ExecuteNonQuery();
            }
            catch(System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public static IranAgent GetIranAgent(int _id)
        {
            var connection = OpenConnection();
            string query = "SELECT * FROM  `AGENTS` WHERE ID = @id";
            IranAgent agent = null;
            try
            {
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", _id);

                
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    agent = new IranAgent(_id, reader.GetString("Rank"), reader.GetInt32("Turns"));
                }
                return agent;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
            finally
            {
                CloseConnection();
            }
        }
        public static void DeleteIranAgent(IranAgent _agent)
        {
            var connection = OpenConnection();
            string query = "DELETE FROM `AGENTS` WHERE ID = @id";
            try
            {
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", _agent.ID);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void UpdateIranAgent(IranAgent _agent)
        {
            var connection = OpenConnection();
            string query = "UPDATE `AGENTS` SET Rank = @rank, Turns = @turns, IsExposed = @exposed" +
                "WHERE ID = @id";
            try
            {
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", _agent.ID);
                cmd.Parameters.AddWithValue("rank", _agent.Rank);
                cmd.Parameters.AddWithValue("turns", _agent.AgentTurn.CounterTurns);
                cmd.Parameters.AddWithValue("exposed", !_agent.IsHiding);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }

    }
}

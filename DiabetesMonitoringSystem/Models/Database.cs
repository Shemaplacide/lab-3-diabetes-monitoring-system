using System.Configuration;
using System.Data;
using MySqlConnector;

namespace DiabetesMonitoringSystem.Models
{
    internal class Database
    {
        private string ConnectionString =>
            ConfigurationManager.ConnectionStrings["DiabetesDatabase"].ConnectionString;

        public DataTable Read(string sql, params object[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            using (MySqlCommand command = CreateCommand(connection, sql, parameters))
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    DataTable data = new DataTable();
                    data.Load(reader);
                    return data;
                }
            }
        }

        public int Write(string sql, params object[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            using (MySqlCommand command = CreateCommand(connection, sql, parameters))
            {
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        // Arguments come in pairs, for example "@id", 12.
        private MySqlCommand CreateCommand(MySqlConnection connection, string sql, object[] parameters)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            for (int index = 0; index < parameters.Length; index += 2)
            {
                object value = parameters[index + 1];
                if (value is System.DateTime)
                {
                    command.Parameters.Add((string)parameters[index], MySqlDbType.DateTime).Value = value;
                }
                else
                {
                    command.Parameters.AddWithValue((string)parameters[index], value);
                }
            }
            return command;
        }
    }
}

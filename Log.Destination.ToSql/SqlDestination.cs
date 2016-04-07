using System;
using System.Configuration;
using System.Data.SqlClient;
using Log.Dto;
using Log.Interface;

namespace Log.Destination.ToSql
{
    public class SqlDestination : IDestination
    {
        public void LogMessage(LogDto logDto)
        {
            var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();

            var command = new SqlCommand("Insert Into Log Values(@message, @messageType)", connection);
            command.Parameters.AddWithValue("@message", logDto.Message);
            command.Parameters.AddWithValue("@messageType", logDto.MessageType);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

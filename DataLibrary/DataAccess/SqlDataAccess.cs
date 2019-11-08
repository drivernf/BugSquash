using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.BusinessLogic
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "TicketDB")
        {
            return ConnStrings.GetConnString(connectionName);
        }

        public static List<T> LoadData<T>(string sql)
        {
            using IDbConnection cnn = new SqlConnection(GetConnectionString());
            return cnn.Query<T>(sql).ToList();
        }

        public static int SaveData<T>(string sql, T data)
        {
            using IDbConnection cnn = new SqlConnection(GetConnectionString());
            return cnn.Execute(sql, data);
        }
    }
}
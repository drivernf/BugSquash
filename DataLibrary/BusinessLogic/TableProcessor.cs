using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class TableProcessor
    {
        public static int CreateTable(string userId, string projectName)
        {
            TableModel data = new TableModel
            {
                userId = userId,
                projectName = projectName
            };

            string sql = $@"CREATE TABLE dbo.@userId@projectName (
                [Id]          INT             IDENTITY (1, 1) NOT NULL,
                [Status]      INT             DEFAULT ((0)) NOT NULL,
                [Urgency]     INT             DEFAULT ((0)) NOT NULL,
                [Description] NVARCHAR (2500) NULL,
                CONSTRAINT [PK__@userId_@projectName] PRIMARY KEY CLUSTERED ([Id] ASC)
            );";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<int> CheckTable(string userId, string projectName)
        {
            string sql = $@"IF EXISTS(
                SELECT 1 FROM sys.tables WHERE name LIKE '{userId}@{projectName}')
                SELECT 1
                ELSE SELECT 0";

            return SqlDataAccess.LoadData<int>(sql);
        }

        public static List<string> GetTables(string userId)
        {
            string sql = $"SELECT name FROM sys.tables WHERE name LIKE '{userId}@%'";

            return SqlDataAccess.LoadData<string>(sql);
        }

        //public static int ModifyTicket(string userId, string projectName, int ticketId, string urgency, string description)
        //{
        //    TicketModel data = new TicketModel
        //    {
        //        TicketId = ticketId,
        //        Status = 0,
        //        Urgency = ConvertUrgency(urgency),
        //        Description = description
        //    };

        //    string sql = $@"update dbo.{userId}@{projectName} set Urgency = @Urgency, Description = @Description where Id = @TicketId;";

        //    return SqlDataAccess.SaveData(sql, data);
        //}
    }
}
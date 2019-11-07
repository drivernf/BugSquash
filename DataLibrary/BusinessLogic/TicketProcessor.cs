using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.BusinessLogic
{
    public static class TicketProcessor
    {
        public static int CreateTicket(int status, int urgency, string description)
        {
            TicketModel data = new TicketModel
            {
                TicketId = 9,
                Status = status,
                Urgency = urgency,
                Description = description
            };

            string sql = @"insert into dbo.TicketTable (TicketId, Status, Urgency, Description)
                            values (@TicketId, @Status, @Urgency, @Description)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<TicketModel> LoadTickets()
        {
            string sql = @"select Id, TicketId, Status, Urgency, Description from dbo.TicketTable;";

            return SqlDataAccess.LoadData<TicketModel>(sql);
        }
    }
}
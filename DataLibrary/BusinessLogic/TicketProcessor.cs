using DataLibrary.Models;
using System.Collections.Generic;

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
                            values (@TicketId, @Status, @Urgency, @Description);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int ModifyTicket(int ticketId, int urgency, string description)
        {
            TicketModel data = new TicketModel
            {
                TicketId = ticketId,
                Status = 0,
                Urgency = urgency,
                Description = description
            };

            string sql = @"update dbo.TicketTable set Urgency = @Urgency, Description = @Description where Id = @TicketId;";

            return SqlDataAccess.SaveData(sql, data);
        }


        public static List<TicketModel> LoadTickets()
        {
            string sql = @"select Id, TicketId, Status, Urgency, Description from dbo.TicketTable;";

            return SqlDataAccess.LoadData<TicketModel>(sql);
        }
    }
}
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public static class TicketProcessor
    {
        public static int CreateTicket(int status, string urgency, string description)
        {
            TicketModel data = new TicketModel
            {
                TicketId = 9,
                Status = status,
                Urgency = ConvertUrgency(urgency),
                Description = description
            };

            string sql = @"insert into dbo.TicketTable (TicketId, Status, Urgency, Description)
                            values (@TicketId, @Status, @Urgency, @Description);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int ModifyTicket(int ticketId, string urgency, string description)
        {
            TicketModel data = new TicketModel
            {
                TicketId = ticketId,
                Status = 0,
                Urgency = ConvertUrgency(urgency),
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

        public static int ConvertUrgency(string urgency)
        {
            if (urgency == "vital") return 3;
            else if (urgency == "average") return 2;
            else if (urgency == "minor") return 1;
            else return 0;
        }

        public static int RemoveTicket(int ticketId)
        {
            TicketModel data = new TicketModel
            {
                TicketId = ticketId
            };

            string sql = @"delete from dbo.TicketTable where Id = @TicketId;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
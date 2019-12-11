using DataLibrary.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataLibrary.BusinessLogic
{
    public static class TicketProcessor
    {
        public static int CreateTicket(string userId, string projectName, int status, string urgency, string description)
        {
            TicketModel data = new TicketModel
            {
                Status = status,
                Urgency = ConvertUrgency(urgency),
                Description = description
            };

            string sql = $@"insert into dbo.{userId}@{projectName} (Status, Urgency, Description)
                            values (@Status, @Urgency, @Description);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int ModifyTicket(string userId, string projectName, int ticketId, string urgency, string description)
        {
            TicketModel data = new TicketModel
            {
                TicketId = ticketId,
                Status = 0,
                Urgency = ConvertUrgency(urgency),
                Description = description
            };

            string sql = $@"update dbo.{userId}@{projectName} set Urgency = @Urgency, Description = @Description where Id = @TicketId;";

            return SqlDataAccess.SaveData(sql, data);
        }


        public static List<TicketModel> LoadTickets(string userId, string projectName)
        {
            string sql = $@"select Id, Status, Urgency, Description from dbo.{userId}@{projectName};";

            return SqlDataAccess.LoadData<TicketModel>(sql);
        }

        public static int ConvertUrgency(string urgency)
        {
            if (urgency == "vital") return 3;
            else if (urgency == "average") return 2;
            else if (urgency == "minor") return 1;
            else return 0;
        }

        public static int RemoveTicket(string userId, string projectName, int ticketId)
        {
            TicketModel data = new TicketModel
            {
                TicketId = ticketId
            };

            string sql = $@"delete from dbo.{userId}@{projectName} where Id = @TicketId;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int StatusChange(string userId, string projectName, int ticketId, int status)
        {
            TicketModel data = new TicketModel
            {
                TicketId = ticketId,
                Status = status
            };

            string sql = $@"update dbo.{userId}@{projectName} set Status = @Status where Id = @TicketId;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
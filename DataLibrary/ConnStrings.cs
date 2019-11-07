using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary
{
    public static class ConnStrings
    {
        public static string GetConnString(string dbName)
        {
            if (dbName == "MVCDemoDB") return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MVCDemoDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            if (dbName == "TicketDB") return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TicketDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return "";
        }
    }
}
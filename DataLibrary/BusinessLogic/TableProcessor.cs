﻿using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class TableProcessor
    {
        public static int CreateTable(string userId)
        {
            TableModel data = new TableModel
            {
                userId = userId
            };

            string sql = $@"CREATE TABLE [dbo].[{userId}] (
                [Id]          INT             IDENTITY (1, 1) NOT NULL,
                [Status]      INT             DEFAULT ((0)) NOT NULL,
                [Urgency]     INT             DEFAULT ((0)) NOT NULL,
                [Description] NVARCHAR (2500) NULL,
                CONSTRAINT [PK__{userId}] PRIMARY KEY CLUSTERED ([Id] ASC)
            );";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<int> GetTable(string userId)
        {
            string sql = $@"IF EXISTS(
                SELECT 1 FROM sys.tables WHERE name LIKE '{userId}')
                SELECT 1
                ELSE SELECT 0";

            return SqlDataAccess.LoadData<int>(sql);
        }
    }
}

/*
    CREATE TABLE [dbo].[TicketTable] (
        [Id]          INT             IDENTITY (1, 1) NOT NULL,
        [TicketId]    INT             NOT NULL,
        [Status]      INT             CONSTRAINT [DF__TicketTab__Statu__4AB81AF0] DEFAULT ((0)) NOT NULL,
        [Urgency]     INT             CONSTRAINT [DF__TicketTab__Urgen__4BAC3F29] DEFAULT ((0)) NOT NULL,
        [Description] NVARCHAR (2500) NULL,
        CONSTRAINT [PK__TicketTa__3214EC07D42FC44B] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
*/
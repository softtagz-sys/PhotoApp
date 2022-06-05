using MySqlConnector;
using PhotoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PhotoApp
{
    class Event : IDBConnectorInterface
    {
        private ulong id;
        private ulong id_account;
        private string eventCode;
        private DateTime startDate;
        private DateTime endDate;
        private string eventName;

        public Event(ulong id, ulong id_account, string eventCode, DateTime startDate, DateTime endDate, string eventName)
        {
            this.id = id;
            this.id_account = id_account;
            this.eventCode = eventCode;
            this.startDate = startDate;
            this.endDate = endDate;
            this.eventName = eventName;
        }

        public Event(MySqlDataReader reader)
        {
            this.id = reader.GetUInt64("id_Event");
            this.id = reader.GetUInt64("id_account");
            this.eventCode = reader.GetString("EventCode");
            this.startDate = new DateTime();
            this.endDate = new DateTime();
            this.eventName = reader.GetString("eventName");
        }

        public string getMySQLColumns()
        {
            return "id_account,EventCode,StartDate,EndDate,EventName";
        }

        public string getMySQLValues()
        {
            return @$"'{this.id_account}','{this.eventCode}','{this.startDate.ToString("u", CultureInfo.GetCultureInfo("nl-BE"))}','{this.endDate.ToString("u", CultureInfo.GetCultureInfo("nl-BE"))}','{this.eventName}'";
        }
    }
}

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
        private ulong eventCode;
        private DateTime startDate;
        private DateTime endDate;
        private string eventName;

        public Event(ulong id, ulong id_account, ulong eventCode, DateTime startDate, DateTime endDate, string eventName)
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
            this.id_account = reader.GetUInt64("id_account");
            this.eventCode = reader.GetUInt64("EventCode");
            this.startDate = reader.GetDateTime("StartDate");
            this.endDate = reader.GetDateTime("EndDate");
            this.eventName = reader.GetString("eventName");

        }

        public string getMySQLColumns()
        {
            return "id_account,EventCode,StartDate,EndDate,EventName";
        }

        public string getMySQLValues()
        {
            string timeFormat = "yyyy-MM-dd HH:mm:ss";
            return @$"'{this.id_account}','{this.eventCode}','{this.startDate.ToString(timeFormat)}','{this.endDate.ToString(timeFormat)}','{this.eventName}'";
        }

        public bool HasEventExpired()
        {
            return DateTime.Now.CompareTo(this.endDate) < 0;
        }
        public bool HasEventBegun()
        {
            return DateTime.Now.CompareTo(this.startDate) > 0;
        }
        public bool IsEventUngoing()
        {
            return DateTime.Now.CompareTo(this.endDate) > 0 && DateTime.Now.CompareTo(this.startDate) < 0;
        }
        public string getName()
        {
            return this.eventName;
        }
        public ulong getId()
        { 
            return this.id;
        }
        public ulong GetEventCode()
        {
            return this.eventCode;
        }
        public DateTime getStartDate()
        {
            return this.startDate;
        }
        public DateTime getEndDate()
        {
            return this.endDate;
        }
    }
}

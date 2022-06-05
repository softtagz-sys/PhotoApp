using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoApp
{
    class Event
    {
        private ulong id;
        private ulong id_account;
        private string eventCode;
        private DateTime startDate;
        private DateTime endDate;
        
        public Event (ulong id, ulong id_account, string eventCode, DateTime startDate, DateTime endDate){
            this.id = id;
            this.id_account = id_account;
            this.eventCode = eventCode;
            this.startDate = startDate;
            this.eventCode = eventCode;
        }

        public Event (MySqlDataReader reader)
        {
            this.id = reader.GetUInt64("id_Event");
            this.id = reader.GetUInt64("id_account");
            this.eventCode = reader.GetString("EventCode");
            
        }
    }
}

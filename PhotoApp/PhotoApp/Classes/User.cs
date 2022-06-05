using MySqlConnector;
using PhotoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoApp
{
    internal class User : IDBConnectorInterface
    {
        private ulong id;
        private string email;
        private string password;
        private bool isHost;


        public User(ulong id, string email, Boolean isHost)
        {
            this.id = id;
            this.email = email;
            this.password = "***secret***";
            this.isHost = isHost;
        }
        public User(MySqlDataReader reader)
        {
            this.id = reader.GetUInt64("id_account");
            this.email = reader.GetString("email");
            this.isHost = (reader.GetInt32("IsHost") == 0 ? false : true);
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getMySQLColumns()
        {
            return "email,password,IsHost";
        }
        public string getMySQLValues()
        {
            return @$"'{this.email}','{this.password}',{(this.isHost ? "1" : "0")}";
        }

    }
}

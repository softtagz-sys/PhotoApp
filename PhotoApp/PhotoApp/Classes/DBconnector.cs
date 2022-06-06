using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PhotoApp
{
    internal class DBconnector
    {
        private static string host = "84.198.150.18";
        // School: "10.23.0.228"
        // Thuis: "84.198.150.18"
        private static string database = "fotoapp";
        private static string userDB = "fotoapp_usr";
        private static string password = "JDMM6sYm";
        private MySqlConnection connection;

        public DBconnector()
        {
            string myConnectionString = $"server={host};port=3306;Database={database};User ID={userDB};Password={password};";

            connection = new MySqlConnection(myConnectionString); // C# 8
        }

        public User getUserbyUsername(string username, string password)
        {
            User user = null;

            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM fotoapp.Account WHERE email = '{username}' AND password = '{password}' LIMIT 1";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                user = new User(reader);
            }
            connection.Close();

            return user;
        }

        public bool isValidUser(string username, string password)
        {
            User u = this.getUserbyUsername(username, password);
            return u != null;
        }

        public int createUser(User user)
        {
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @$"INSERT INTO fotoapp.Account ({user.getMySQLColumns()}) VALUES({user.getMySQLValues()});";
            using var reader = command.ExecuteReader();

            return reader.RecordsAffected;
        }

        public List<User> getUsers() {
            List<User> users = new List<User>();

            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM fotoapp.Account;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User(reader));
            }
            connection.Close();

            return users;
        }

        public List<Event> listEventsForUser(User user){
            List<Event> list = new List<Event>();

            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM fotoapp.Event WHERE Event.id_account='{user.getId()}';";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Event(reader));
            }
            connection.Close();

            return list;
        }

        public int createEvent(Event item){
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @$"INSERT INTO fotoapp.Event ({item.getMySQLColumns()}) VALUES({item.getMySQLValues()});";
            using var reader = command.ExecuteReader();

            return reader.RecordsAffected;
        }

        public Event getEventbyEventCode(ulong eventCode)
        {
            Event item = null;

            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM fotoapp.Event WHERE EventCode = '{eventCode}' LIMIT 1;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                item = new Event(reader);
            }
            connection.Close();

            return item;
        }
        public bool isValidEvent(ulong eventCode)
        {
            Event e = this.getEventbyEventCode(eventCode);
            return e != null;
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordApp.Model
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public static void Insert(User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                int rows = conn.Insert(user);

                //if (rows > 0)
                //{
                //    DisplayAlert("Success", "Client successfully added", "Ok");
                //}
                //else
                //    DisplayAlert("Failure", "Failed to add client", "Ok");
            }
        }
    }
}

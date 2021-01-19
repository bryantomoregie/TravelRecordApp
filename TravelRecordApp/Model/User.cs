using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TravelRecordApp.Model
{
    public class User : INotifyPropertyChanged
    {
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


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

        //public static bool Login(string email, string password)
        //{
        //    bool isEmailEmpty = string.IsNullOrEmpty(email);
        //    bool isPasswordEmpty = string.IsNullOrEmpty(password);

        //    if (isEmailEmpty || isPasswordEmpty)
        //    {
        //        return false; 
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        public static bool Login(string email, string password)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                
                var userTable = conn.Table<User>().ToList();
                try
                {
                    var userSU = (from u in userTable
                                  where u.Email == email
                                  select u).Single();
                    if(userSU.Password != password)
                    {
                        return false;
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
               

               

                return true;
            }
        }
    }
}

/*
 * This will be a login method in the User class. Each user can login!!!
 I need to get the table that will represent the user table in the db
I need to use LINQ to query that table and get the email that matches 
Then see if the password matches the email 
If true, return true. If false, return false.
 */

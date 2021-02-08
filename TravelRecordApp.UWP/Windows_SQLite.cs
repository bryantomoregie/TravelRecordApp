using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.UWP;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Windows_SQLite))]
namespace TravelRecordApp.UWP
{
    class Windows_SQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Member.sqlite";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}

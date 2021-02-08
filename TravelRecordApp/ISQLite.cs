using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordApp
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}

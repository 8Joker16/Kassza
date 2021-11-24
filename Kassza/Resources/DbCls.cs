using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Kassza.Resources
{
    public static class DbCls
    {
        private static string GetPathTODb()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kassza");
        }
        public static void CreateDB()
        {
            if (!Directory.Exists(GetPathTODb()))
                Directory.CreateDirectory(GetPathTODb());

            SQLiteConnection.CreateFile(Path.Combine(GetPathTODb(), "maindb.sqlite"));
        }

        private static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection($"Data source={Path.Combine(GetPathTODb(),"maindb.sqlite")};Version=3;");
        }

        public static void CreateTables()
        {
            SQLiteConnection conn = GetConnection();
            conn.Open();
            string sql = @"create table User(
            Id integer PRIMARY KEY AUTOINCREMENT,
            UserName varchar(30) NOT NULL,
            Password varchar(10) NOT NULL
            );";

            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}

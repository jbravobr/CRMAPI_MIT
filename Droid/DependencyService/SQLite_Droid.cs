using System;
using System.IO;
using MITCRMApp.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace MITCRMApp.Droid
{
    public class SQLite_Droid : ISQLite
    {
        public SQLiteConnection RetornaConexao()
        {
            var sqliteFilename = "MITCRMapp.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}

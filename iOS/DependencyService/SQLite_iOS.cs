using System;
using System.IO;
using MITCRMApp.iOS;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace MITCRMApp.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection RetornaConexao()
        {
            var sqliteFilename = "MITCRMAPP.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}

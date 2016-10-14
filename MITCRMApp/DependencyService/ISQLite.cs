using System;
namespace MITCRMApp
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection RetornaConexao();
    }
}

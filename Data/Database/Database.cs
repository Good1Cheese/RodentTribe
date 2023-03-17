using RodentTribe.Data.Models;
using SQLite;

namespace RodentTribe.Data.Database;

public class Database
{
    public const string DatabaseFileName = "RodentTribe.db";

    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);

    public SQLiteAsyncConnection Connection { get; private set; }

    public Database()
    {
        Connection = new SQLiteAsyncConnection(DatabasePath);

        Connection.CreateTableAsync<Сloset>();
        Connection.CreateTableAsync<Box>();
        Connection.CreateTableAsync<Rodent>();
    }
}

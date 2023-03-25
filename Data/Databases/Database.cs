using RodentTribe.Data.Models;
using SQLite;

namespace RodentTribe.Data.Databases;

public class Database
{
    public const string DATABASE_FILE_NAME = "RodentTribe.db";

    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DATABASE_FILE_NAME);

    public SQLiteAsyncConnection Connection { get; private set; }

    public Database()
    {
        Connection = new SQLiteAsyncConnection(DatabasePath);

        Connection.CreateTableAsync<Сloset>();
        Connection.CreateTableAsync<Box>();
        Connection.CreateTableAsync<Rodent>();
    }
}

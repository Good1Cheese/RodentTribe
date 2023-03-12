using RodentTribe.Data.Models;
using SQLite;

namespace RodentTribe.Data;

public class Database
{
    public const string DatabaseFileName = "RodentTribe.db";
    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);

    public SQLiteConnection Connection { get; private set; }

    public Database()
    {
        Connection = new(DatabasePath);

        Connection.CreateTable<Сloset>();
    }
}

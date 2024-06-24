using ConsoleApp5.Models;

namespace ConsoleApp5;

public class DatabaseServisce
{
    private static PostgresContext db;

    public static PostgresContext  GetDbContext()
    {
        if (db == null)
        {
            db = new PostgresContext();
        }
        return db;
    }
}
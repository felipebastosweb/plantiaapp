using SQLite;

using FileSystem = Microsoft.Maui.Storage.FileSystem;

using PlantiaApp.Shared.Core.Entities;

namespace PlantiaApp.Shared.Core.Contexts
{
    public class SQLiteContexts
    {
        public const string DatabaseFilename = "database.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        
        public SQLiteAsyncConnection? Database { get; set; }

        private async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DatabasePath, Flags);
            await InitAuthentication();
        }

        private async Task InitAuthentication()
        {
            await Database!.CreateTableAsync<User>();
        }
    }
}

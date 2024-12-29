using SQLite;

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
            Path.Combine(
                //FileSystem.AppDataDirectory, DatabasePath);
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
        
        public SQLiteAsyncConnection? Database { get; set; }

        public SQLiteContexts() { }

        public async Task Init()
        {
            Console.WriteLine("Criando o banco de dados.");
            if (Database is not null)
            {
                Console.WriteLine("O banco de dados já existe.");
                return;
            }

            Database = new SQLiteAsyncConnection(DatabasePath, Flags);

            await Database!.CreateTableAsync<User>();
            //await InitAuthentication();
            Console.WriteLine("O banco de dados foi criado");
        }

        private async Task InitAuthentication()
        {
            await Database!.CreateTableAsync<User>();
        }
    }
}

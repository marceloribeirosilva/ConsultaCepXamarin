using BuscaCep.Providers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaCep.Data
{
    class DatabaseService
    {
        private static Lazy<DatabaseService> _Lazy = new Lazy<DatabaseService>(()=> new DatabaseService());

        public static DatabaseService Current { get => _Lazy.Value; }

        private DatabaseService()
        {
            var dbPath = Xamarin.Forms.DependencyService.Get<ISQLiteDatabasePathProvider>().GetDatabasePath();
            _SQLiteConnection = new SQLiteConnection();
        }

        private readonly SQLiteConnection _SQLiteConnection;
    }
}

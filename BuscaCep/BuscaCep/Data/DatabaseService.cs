using BuscaCep.Data.Dtos;
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

        private readonly SQLiteConnection _SQLiteConnection;

        private DatabaseService()
        {
            var dbPath = Xamarin.Forms.DependencyService.Get<ISQLiteDatabasePathProvider>().GetDatabasePath();
            _SQLiteConnection = new SQLiteConnection(dbPath);
            _SQLiteConnection.CreateTable<CepDto>();
        }

        public bool CepSave(CepDto cep) => _SQLiteConnection.InsertOrReplace(cep) > 0;

        public List<CepDto> CepGetAll() => _SQLiteConnection.Table<CepDto>().ToList();

        public CepDto CepGet(Guid id) => _SQLiteConnection.Find<CepDto>(id);
    }
}

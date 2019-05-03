using System;
using System.IO;
using BuscaCep.iOS.Providers;
using BuscaCep.Providers;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSSQLiteDatabasePathProvider))]

namespace BuscaCep.iOS.Providers
{
    sealed class IOSSQLiteDatabasePathProvider : ISQLiteDatabasePathProvider
    {
        public IOSSQLiteDatabasePathProvider()
        {

        }

        public string GetDatabasePath()
        {
            var databaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", "Databases");

            if (!Directory.Exists(databaseFolder))
                Directory.CreateDirectory(databaseFolder);

            return Path.Combine(databaseFolder, "BuscaCep.db3");
        }
    }
}
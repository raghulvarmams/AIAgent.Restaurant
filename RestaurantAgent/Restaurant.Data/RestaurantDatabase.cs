using LiteDB;
using Restaurant.Domain;

namespace Restaurant.Data
{
    public class RestaurantDatabase : IDisposable
    {
        public static string DefaultPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "RestaurantApp", "restaurant.db");
        private readonly LiteDatabase _database;

        public LiteDatabase Database => _database;

        public RestaurantDatabase()
        {
            var fullPath = Path.GetFullPath(DefaultPath);
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

            _database = new LiteDatabase(new ConnectionString
            {
                Filename = fullPath,
                Connection = ConnectionType.Shared
            });

            _database.GetCollection<MenuItem>("menuitems").EnsureIndex(x => x.Id, unique: true);
            DatabaseSeeder.Seed(_database);
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}

using LiteDB;
using Féléves_Szerveroldali.Models;

namespace Féléves_Szerveroldali.Data
{
    public class LiteDbContext
    {
        private readonly LiteDatabase _database;

        public LiteDbContext(string databasePath)
        {
            _database = new LiteDatabase(databasePath);
            //_database.DropCollection("csapatok");
            SeedData();
        }
        private void SeedData()
        {
            SeedEmber();
            SeedCsapat();
            SeedFeladat();
        }
        public ILiteCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
        private void SeedEmber()
        {
            var collection = _database.GetCollection<Ember>("emberek");
            if (collection.Count() == 0)
            {
                var emberek = new List<Ember>
                {
                  new Ember { Id = 1, Név = "Dávid", Csapat = "nincs"},
                  new Ember { Id = 2, Név = "Sanyi", Csapat = "nincs" },
                  new Ember { Id = 3, Név = "Feri", Csapat = "nincs"},
                  new Ember { Id = 4, Név = "Ági", Csapat = "nincs" },
                  new Ember { Id = 5, Név = "Géza", Csapat = "nincs" },
                  new Ember { Id = 6, Név = "Gáspár", Csapat = "nincs"}
                };
                collection.InsertBulk(emberek);
            }
        }
        private void SeedCsapat()
        {
            var collection = _database.GetCollection<Csapat>("csapatok");
            if (collection.Count() == 0)
            {
                var csapatok = new List<Csapat>
                {
                  new Csapat { Id = 1, Name = "A menők", Csapattagok = new List<string>(){"senki","senki","senki","senki"}, Feladat = "nincs" },
                  new Csapat { Id = 2, Name = "A nem-menők", Csapattagok = new List<string>(){"senki","senki","senki","senki"}, Feladat = "nincs"},
                  new Csapat { Id = 3, Name = "A futók", Csapattagok = new List<string>(){"senki","senki","senki","senki"}, Feladat = "nincs"}
                };
                collection.InsertBulk(csapatok);
            }
        }

        private void SeedFeladat()
        {
            var collection = _database.GetCollection<Feladat>("feladatok");
            if (collection.Count() == 0)
            {
                var feladatok = new List<Feladat>
                {
                  new Feladat { Id = 1, Name = "Űrsikló"},
                  new Feladat { Id = 2, Name = "JackSparrow-CompanionBot"},
                  new Feladat { Id = 3, Name = "Pegazus2"}
                };
                collection.InsertBulk(feladatok);
            }
        }
        public ILiteCollection<Ember> Emberek => _database.GetCollection<Ember>("emberek");
        public ILiteCollection<Csapat> Csapatok => _database.GetCollection<Csapat>("csapatok");
        public ILiteCollection<Feladat> Feladatok => _database.GetCollection<Feladat>("feladatok");
    }
}

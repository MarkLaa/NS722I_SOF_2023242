using Féléves_Szerveroldali.Models;
namespace Féléves_Szerveroldali.Data
{
    public class FeladatRepository : IFeladatRepository
    {
        private readonly LiteDbContext context;
        public FeladatRepository(LiteDbContext context)
        {
            this.context = context;
        }
        public void Create(Feladat feladat)
        {
            context.Feladatok.Insert(feladat);

        }

        public IEnumerable<Feladat> Read()
        {
            return context.Feladatok.FindAll();

        }

        public Feladat? Read(int id)
        {
            return context.Feladatok.FindById(id);
        }

        public void Delete(int id)
        {
            context.Feladatok.Delete(id);
        }

        public void Update(Feladat feladat)
        {
            var old = Read(feladat.Id);
            old.Name = feladat.Name;
            context.Feladatok.Update(old);
        }
    }
}

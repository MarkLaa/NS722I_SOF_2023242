using Féléves_Szerveroldali.Models;
namespace Féléves_Szerveroldali.Data
{
    public class EmberRepository : IEmberRepository
    {
        private readonly LiteDbContext context;
        public EmberRepository(LiteDbContext context)
        {
            this.context = context;
        }

        public void Create(Ember ember)
        {
            context.Emberek.Insert(ember);

        }

        public IEnumerable<Ember> Read()
        {
            return context.Emberek.FindAll();

        }

        public Ember? Read(int id)
        {
            return context.Emberek.FindById(id);
        }

        public void Delete(int id)
        {
            context.Emberek.Delete(id);
        }

        public void Update(Ember ember)
        {
            var old = Read(ember.Id);
            old.Név = ember.Név;
            old.Csapat = ember.Csapat;
            context.Emberek.Update(old);
        }
    }
}

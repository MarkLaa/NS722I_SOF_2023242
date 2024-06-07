using Féléves_Szerveroldali.Models;
namespace Féléves_Szerveroldali.Data
{
    public class CsapatRepository : ICsapatRepository
    {
        private readonly LiteDbContext context;
        public CsapatRepository(LiteDbContext context)
        {
            this.context = context;
        }
        public void Create(Csapat csapat)
        {
            context.Csapatok.Insert(csapat);

        }

        public IEnumerable<Csapat> Read()
        {
            return context.Csapatok.FindAll();

        }

        public Csapat? Read(int id)
        {
            return context.Csapatok.FindById(id);
        }

        public void Delete(int id)
        {
            context.Csapatok.Delete(id);
        }

        public void Update(Csapat csapat)
        {
            var old = Read(csapat.Id);
            old.Name = csapat.Name;
            old.Feladat = csapat.Feladat;
            old.Csapattagok = csapat.Csapattagok;
            context.Csapatok.Update(old);
        }
    }
}

using Féléves_Szerveroldali.Models;

namespace Féléves_Szerveroldali.Data
{
    public interface IEmberRepository
    {
        void Create(Ember ember);
        void Delete(int id);
        IEnumerable<Ember> Read();
        Ember? Read(int id);
        void Update(Ember ember);
    }
}
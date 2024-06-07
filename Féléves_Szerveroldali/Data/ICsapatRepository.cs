using Féléves_Szerveroldali.Models;

namespace Féléves_Szerveroldali.Data
{
    public interface ICsapatRepository
    {
        void Create(Csapat csapat);
        void Delete(int id);
        IEnumerable<Csapat> Read();
        Csapat? Read(int id);
        void Update(Csapat csapat);
    }
}
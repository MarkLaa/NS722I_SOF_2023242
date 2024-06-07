using Féléves_Szerveroldali.Models;

namespace Féléves_Szerveroldali.Data
{
    public interface IFeladatRepository
    {
        void Create(Feladat feladat);
        void Delete(int id);
        IEnumerable<Feladat> Read();
        Feladat? Read(int id);
        void Update(Feladat feladat);
    }
}
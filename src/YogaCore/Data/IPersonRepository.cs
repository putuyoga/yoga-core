using System.Collections.Generic;
using System.Threading.Tasks;
using YogaCore.Models;

namespace YogaCore.Data
{
    public interface IPersonRepository
    {
        Person Get(string id);

        IEnumerable<Person> Get();

        Task<Person> Create(Person item, string password);

        Person Update(Person item);

        void Delete(Person item);
    }
}
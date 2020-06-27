using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IPersonRespository : IRespository
    {
        Task<IEnumerable<Person>> GetAsync();
        IQueryable<Person> GetQuery();
        Task<Person> GetAsync(Guid id);
        Person Add(Person item);
        Person Update(Person item);
    }
}

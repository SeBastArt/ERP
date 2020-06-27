using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface ICountryRespository : IRespository
    {
        Task<IEnumerable<Country>> GetAsync();
        IQueryable<Country> GetQuery();
        Task<Country> GetAsync(Guid id);
        Country Add(Country item);
        Country Update(Country item);
    }
}

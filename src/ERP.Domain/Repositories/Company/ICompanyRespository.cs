using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface ICompanyRespository : IRespository
    {
        Task<IEnumerable<Company>> GetAsync();
        IQueryable<Company> GetQuery();
        Task<Company> GetAsync(Guid id);
        Company Add(Company item);
        Company Update(Company item);
    }
}

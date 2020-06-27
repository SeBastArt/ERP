using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface ICompanyTypeRespository : IRespository
    {
        Task<IEnumerable<CompanyType>> GetAsync();
        IQueryable<CompanyType> GetQuery();
        Task<CompanyType> GetAsync(Guid id);
        CompanyType Add(CompanyType item);
        CompanyType Update(CompanyType item);
    }
}

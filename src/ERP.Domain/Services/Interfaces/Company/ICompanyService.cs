using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyResponse>> GetCompaniesAsync();
        IQueryable<CompanyResponse> GetCompaniesQuery();
        Task<CompanyResponse> GetCompanyAsync(Guid id);
        Task<CompanyResponse> AddCompanyAsync(AddCompanyRequest request);
        Task<CompanyResponse> EditCompanyAsync(EditCompanyRequest request);
        Task<CompanyResponse> DeleteCompanyAsync(DeleteCompanyRequest request);
    }
}

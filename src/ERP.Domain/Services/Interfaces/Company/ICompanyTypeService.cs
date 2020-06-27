using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface ICompanyTypeService
    {
        Task<IEnumerable<CompanyTypeResponse>> GetCompanyTypesAsync();
        IQueryable<CompanyTypeResponse> GetCompanyTypesQuery();
        Task<CompanyTypeResponse> GetCompanyTypeAsync(Guid id);
        Task<CompanyTypeResponse> AddCompanyTypeAsync(AddCompanyTypeRequest request);
        Task<CompanyTypeResponse> EditCompanyTypeAsync(EditCompanyTypeRequest request);
        Task<CompanyTypeResponse> DeleteCompanyTypeAsync(DeleteCompanyTypeRequest request);
    }
}

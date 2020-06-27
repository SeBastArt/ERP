using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface ICompanyTypeMapper
    {
        CompanyType Map(AddCompanyTypeRequest request);
        CompanyType Map(EditCompanyTypeRequest request);
        CompanyTypeResponse Map(CompanyType item);
    }
}

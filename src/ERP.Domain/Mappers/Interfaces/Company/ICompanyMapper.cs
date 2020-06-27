using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface ICompanyMapper
    {
        Company Map(AddCompanyRequest request);
        Company Map(EditCompanyRequest request);
        CompanyResponse Map(Company item);
    }
}

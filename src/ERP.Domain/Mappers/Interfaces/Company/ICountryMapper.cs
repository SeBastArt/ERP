using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface ICountryMapper
    {
        Country Map(AddCountryRequest request);
        Country Map(EditCountryRequest request);
        CountryResponse Map(Country country);
    }
}

using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryResponse>> GetCountriesAsync();
        IQueryable<CountryResponse> GetCountriesQuery();
        Task<CountryResponse> GetCountryAsync(Guid id);
        Task<CountryResponse> AddCountryAsync(AddCountryRequest request);
        Task<CountryResponse> EditCountryAsync(EditCountryRequest request);
        Task<CountryResponse> DeleteCountryAsync(DeleteCountryRequest request);
    }
}

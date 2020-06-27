using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class CountryMapper : ICountryMapper
    {

        public Country Map(AddCountryRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Country country = new Country
            {
                Iso3cc = request.Iso3cc,
                Iso2cc = request.Iso2cc,
                IsoNumerical = request.IsoNumerical,
                EconomicArea = request.EconomicArea,
                Name = request.Name,
                Type = request.Type,
            };

            return country;
        }

        public Country Map(EditCountryRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Country country = new Country
            {
                Id = request.Id,
                Iso3cc = request.Iso3cc,
                Iso2cc = request.Iso2cc,
                IsoNumerical = request.IsoNumerical,
                EconomicArea = request.EconomicArea,
                Name = request.Name,
                Type = request.Type,
            };

            return country;
        }

        public CountryResponse Map(Country request)
        {
            if (request == null)
            {
                return null;
            };

            CountryResponse response = new CountryResponse
            {
                Id = request.Id,
                Iso3cc = request.Iso3cc,
                Iso2cc = request.Iso2cc,
                IsoNumerical = request.IsoNumerical,
                EconomicArea = request.EconomicArea,
                Name = request.Name,
                Type = request.Type,
            };

            return response;
        }

        public IQueryable<CountryResponse> Map(IQueryable<Country> country)
        {

            if (country == null)
            {
                return null;
            };

            IQueryable<CountryResponse> response = country.Select(x => new CountryResponse()
            {
                Id = x.Id,
                Iso3cc = x.Iso3cc,
                Iso2cc = x.Iso2cc,
                IsoNumerical = x.IsoNumerical,
                EconomicArea = x.EconomicArea,
                Name = x.Name,
                Type = x.Type,
            });

            return response;
        }
    }
}

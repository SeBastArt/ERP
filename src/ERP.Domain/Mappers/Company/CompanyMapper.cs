using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System.Linq;

namespace ERP.Domain.Mappers
{
    public class CompanyMapper : ICompanyMapper
    {
        private readonly ICompanyMapper _addressMapper;
        private readonly IFAGBinaryMapper _fagBinaryMapper;
        private readonly ICountryMapper _countryMapper;
        private readonly ICompanyTypeMapper _companyTypeMapper;

        public CompanyMapper(ICompanyMapper addressMapper, IFAGBinaryMapper fagBinaryMapper, ICountryMapper countryMapper, ICompanyTypeMapper companyTypeMapper)
        {
            _addressMapper = addressMapper;
            _fagBinaryMapper = fagBinaryMapper;
            _countryMapper = countryMapper;
            _companyTypeMapper = companyTypeMapper;
        }

        public Company Map(AddCompanyRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Company address = new Company
            {
                Name = request.Name,
                Addition = request.Addition,
                Addition2 = request.Addition2,
                Street = request.Street,
                PostCode = request.PostCode,
                City = request.City,
                Email = request.Email,
                Phone = request.Phone,
                Fax = request.Fax,
                VatId = request.VatId,
                TimeZone = request.TimeZone,
                ParentId = request.ParentId,
                CountryId = (System.Guid)request.CountryId,
                LogoId = request.LogoId,
                CompanyTypeId = (System.Guid)request.CompanyTypeId
            };
            return address;
        }

        public Company Map(EditCompanyRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Company address = new Company
            {
                Id = request.Id,
                Name = request.Name,
                Addition = request.Addition,
                Addition2 = request.Addition2,
                Street = request.Street,
                PostCode = request.PostCode,
                City = request.City,
                Email = request.Email,
                Phone = request.Phone,
                Fax = request.Fax,
                VatId = request.VatId,
                TimeZone = request.TimeZone,
                ParentId = request.ParentId,
                CountryId = request.CountryId,
                LogoId = request.LogoId,
                CompanyTypeId = request.CompanyTypeId
            };

            return address;
        }

        public CompanyResponse Map(Company address)
        {
            if (address == null)
            {
                return null;
            };

            CompanyResponse response = new CompanyResponse
            {
                Id = address.Id,
                Name = address.Name,
                Addition = address.Addition,
                Addition2 = address.Addition2,
                Street = address.Street,
                PostCode = address.PostCode,
                City = address.City,
                Email = address.Email,
                Phone = address.Phone,
                Fax = address.Fax,
                VatId = address.VatId,
                TimeZone = address.TimeZone,
                ParentId = (System.Guid)address.ParentId,
                Parent = _addressMapper.Map(address.Parent),
                CountryId = address.CountryId,
                Country = _countryMapper.Map(address.Country),
                LogoId = (System.Guid)address.LogoId,
                Logo = _fagBinaryMapper.Map(address.Logo),
                CompanyTypeId = address.CompanyTypeId,
                CompanyType = _companyTypeMapper.Map(address.CompanyType)
            };

            return response;
        }

        public IQueryable<CompanyResponse> Map(IQueryable<Company> address)
        {

            if (address == null)
            {
                return null;
            };

            IQueryable<CompanyResponse> response = address.Select(x => new CompanyResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Addition = x.Addition,
                Addition2 = x.Addition2,
                Street = x.Street,
                PostCode = x.PostCode,
                City = x.City,
                Email = x.Email,
                Phone = x.Phone,
                Fax = x.Fax,
                VatId = x.VatId,
                TimeZone = x.TimeZone,
                ParentId = (System.Guid)x.ParentId,
                Parent = _addressMapper.Map(x.Parent),
                CountryId = x.CountryId,
                Country = _countryMapper.Map(x.Country),
                LogoId = (System.Guid)x.LogoId,
                Logo = _fagBinaryMapper.Map(x.Logo),
                CompanyTypeId = x.CompanyTypeId,
                CompanyType = _companyTypeMapper.Map(x.CompanyType)
            });

            return response;
        }
    }
}

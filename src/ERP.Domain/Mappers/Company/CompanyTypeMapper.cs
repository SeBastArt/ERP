using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class CompanyTypeMapper : ICompanyTypeMapper
    {
        public CompanyType Map(AddCompanyTypeRequest request)
        {
            if (request == null)
            {
                return null;
            }

            CompanyType companyType = new CompanyType
            {
                Name = request.Name,
                Type = request.Type,
              
            };

            return companyType;
        }

        public CompanyType Map(EditCompanyTypeRequest request)
        {
            if (request == null)
            {
                return null;
            }

            CompanyType companyType = new CompanyType
            {
                Id = request.Id,
                Name = request.Name,
                Type = request.Type,
            };

            return companyType;
        }

        public CompanyTypeResponse Map(CompanyType request)
        {
            if (request == null)
            {
                return null;
            };

            CompanyTypeResponse response = new CompanyTypeResponse
            {
                Id = request.Id,
                Name = request.Name,
                Type = request.Type,
            };

            return response;
        }

        public IQueryable<CompanyTypeResponse> Map(IQueryable<CompanyType> companyType)
        {

            if (companyType == null)
            {
                return null;
            };

            IQueryable<CompanyTypeResponse> response = companyType.Select(x => new CompanyTypeResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
            });

            return response;
        }
    }
}

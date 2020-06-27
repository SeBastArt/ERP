using ERP.Domain.Models;
using System;

namespace ERP.Domain.Responses
{
    public class CompanyResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Addition { get; set; }
        public string Addition2 { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string VatId { get; set; }
        public string TimeZone { get; set; }
        public Guid ParentId { get; set; }
        public CompanyResponse Parent { get; set; }
        public Guid CountryId { get; set; }
        public CountryResponse Country { get; set; }
        public Guid LogoId { get; set; }
        public FAGBinaryResponse Logo { get; set; }
        public Guid CompanyTypeId { get; set; }
        public CompanyTypeResponse CompanyType { get; set; }
    }
}

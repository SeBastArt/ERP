using ERP.Domain.Models;
using System;
using System.Collections.Generic;

namespace ERP.Domain.Responses
{
    public class CompanyTypeResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public ICollection<Company> Companyes { get; set; }
    }
}

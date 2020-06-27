using System;

namespace ERP.Domain.Requests
{
    public class EditCompanyTypeRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}

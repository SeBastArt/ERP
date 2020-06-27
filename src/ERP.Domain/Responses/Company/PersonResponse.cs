using ERP.Domain.Models;
using System;
using System.Collections.Generic;

namespace ERP.Domain.Responses
{
    public class PersonResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Sex { get; set; }
        public string Department { get; set; }
        public string PhoneOffice { get; set; }
        public string PhonePrivate { get; set; }
        public string Email { get; set; }
        public Guid PictureId { get; set; }
        public FAGBinaryResponse Picture { get; set; }
        public ICollection<CompanyPersonRelation> CompanyPersonRelations { get; }
    }
}

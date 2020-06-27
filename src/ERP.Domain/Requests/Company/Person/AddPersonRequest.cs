using ERP.Domain.Models;
using ERP.Domain.Responses;
using System;

namespace ERP.Domain.Requests
{
    public class AddPersonRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Sex { get; set; }
        public string Department { get; set; }
        public string PhoneOffice { get; set; }
        public string PhonePrivate { get; set; }
        public string Email { get; set; }
        public Guid PictureId { get; set; }
    }
}

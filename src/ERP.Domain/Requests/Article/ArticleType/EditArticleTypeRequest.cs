using System;

namespace ERP.Domain.Requests
{
    public class EditArticleTypeRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NatureType { get; set; }
    }
}

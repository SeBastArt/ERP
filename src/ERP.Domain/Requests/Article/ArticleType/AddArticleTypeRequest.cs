using System;

namespace ERP.Domain.Requests
{
    public class AddArticleTypeRequest
    {
        public Guid ArticleTypeId { get; set; }
        public string Name { get; set; }
        public string NatureType { get; set; }
    }
}

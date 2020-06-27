using System;

namespace ERP.Domain.Responses
{
    public class ArticleTypeResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NatureType { get; set; }
    }
}

using System;

namespace ERP.Domain.Responses
{
    public class ArticleGroupResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

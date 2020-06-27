using System;

namespace ERP.Domain.Requests
{
    public class EditArticleGroupRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

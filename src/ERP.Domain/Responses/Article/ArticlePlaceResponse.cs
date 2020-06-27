using ERP.Domain.Models;
using System;

namespace ERP.Domain.Responses
{
    public class ArticlePlaceResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyResponse Company { get; set; }
        public decimal ReservedQty { get; set; }
        public decimal MinimumQty { get; set; }
        public decimal OpoQty { get; set; }
    }
}

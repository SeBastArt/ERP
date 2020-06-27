using System;

namespace ERP.Domain.Requests
{
    public class AddArticlePlaceRequest
    {
        public Guid CompanyId { get; set; }
        public decimal ReservedQty { get; set; }
        public decimal MinimumQty { get; set; }
        public decimal OpoQty { get; set; }
    }
}

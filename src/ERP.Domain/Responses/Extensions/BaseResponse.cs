using ERP.Domain.Models;
using System;
using System.Collections.Generic;

namespace ERP.Domain.Responses
{
    public class BaseResponse
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public bool IsInactive { get; set; }
        public ICollection<FAGText> Infos { get; set; }
    }
}

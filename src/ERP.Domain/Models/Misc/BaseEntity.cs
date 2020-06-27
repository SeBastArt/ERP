using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public abstract class BaseEntity
    {
        [Column("created")]
        public DateTime Created { get; set; }

        [Column("modified")]
        public DateTime Modified { get; set; }

        [Column("created_by")]
        public long CreatedBy { get; set; }

        [Column("modified_by")]
        public long ModifiedBy { get; set; }

        public bool IsInactive { get; set; }

        public ICollection<FAGText> Infos { get; set; }// = new List<FAGText>();
    }
}

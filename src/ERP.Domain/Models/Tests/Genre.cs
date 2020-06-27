using System;
using System.Collections.Generic;

namespace ERP.Domain.Models
{
    public class Genre
    {
        public Guid GenreId { get; set; }
        public string GenreDescription { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
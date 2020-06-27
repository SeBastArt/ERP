using ERP.Domain.Models;
using System;
using System.Collections.Generic;

namespace ERP.Domain.Responses
{
    public class CountryResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Iso3cc { get; set; }
        public string Iso2cc { get; set; }
        public int IsoNumerical { get; set; }
        public int EconomicArea { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public ICollection<Company> Adresss { get; set; }
    }
}

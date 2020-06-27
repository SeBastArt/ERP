namespace ERP.Domain.Requests
{
    public class AddCountryRequest
    {
        public string Iso3cc { get; set; }
        public string Iso2cc { get; set; }
        public int IsoNumerical { get; set; }
        public int EconomicArea { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}

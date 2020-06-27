namespace ERP.Domain.Requests
{
    public class AddFAGTextRequest
    {
        public string Text { get; set; }
        public string TextRTF { get; set; }
        public string Iso3cc { get; set; }
        public string Iso2cc { get; set; }
    }
}

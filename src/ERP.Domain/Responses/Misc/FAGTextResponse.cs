using System;

namespace ERP.Domain.Responses
{
    public class FAGTextResponse
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string TextRTF { get; set; }
        public string Iso3cc { get; set; }
        public string Iso2cc { get; set; }
    }
}

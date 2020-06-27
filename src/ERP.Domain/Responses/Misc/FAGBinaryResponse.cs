using System;

namespace ERP.Domain.Responses
{
    public class FAGBinaryResponse
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}

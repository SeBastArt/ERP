using System;

namespace ERP.Domain.Requests
{
    public class EditFAGBinaryRequest
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}

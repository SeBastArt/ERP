namespace ERP.Domain.Requests
{
    public class AddFAGBinaryRequest
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}

namespace ERP.Domain.Extensions
{
    /// <summary>
    /// JsonErrorPayload
    /// </summary>
    public class JsonErrorPayload
    {
        public int EventId { get; set; }
        public object DetailedMessage { get; set; }
    }
}

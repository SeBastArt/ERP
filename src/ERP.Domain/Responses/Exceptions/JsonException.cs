using System.Collections.Generic;

namespace ERP.Domain.Responses
{
    public class JsonException
    {
        public int EventId { get; set; }
        public List<string> DetailedMessages { get; set; }

        public JsonException()
        {
            DetailedMessages = new List<string>();
        }
    }
}

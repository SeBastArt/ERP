using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.API.Extensions.Swagger.SwaggerExamples.Requests.FAGBinary
{
    /// <summary>
    /// EditFAGBinaryRequestExample
    /// </summary>
    public class EditFAGBinaryRequestExample : IExamplesProvider<EditFAGBinaryRequest>
    {
        /// <summary>
        /// Array of bytes
        /// </summary>
        public static byte[] byteArray = { (byte)'i', (byte)'V', (byte)'B', (byte)'O', (byte)'R', (byte)'w', (byte)'0', (byte)'K', (byte)'G', (byte)'g', (byte)'o' };
        /// <summary>
        /// GetExamples
        /// </summary>
        /// <returns>EditFAGBinaryRequest</returns>
        public EditFAGBinaryRequest GetExamples()
        {
            return new EditFAGBinaryRequest
            {
                Id = Guid.Parse("0e57aca2-bd14-4242-bdfb-e89a26fe7270"),
                Data = byteArray,
                FileName = "/dst/icon_03.png"
            };
        }
    }
}

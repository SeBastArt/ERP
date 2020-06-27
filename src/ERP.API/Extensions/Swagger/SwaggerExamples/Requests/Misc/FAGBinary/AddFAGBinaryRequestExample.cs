using ERP.Domain.Models;
using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddCompanyRequestExample
    /// </summary>
    public class AddFAGBinaryRequestExample : IExamplesProvider<AddFAGBinaryRequest>
    {
        /// <summary>
        /// Array of bytes
        /// </summary>
        public static byte[] byteArray = { (byte)'i', (byte)'V', (byte)'B', (byte)'O', (byte)'R', (byte)'w', (byte)'0', (byte)'K', (byte)'G', (byte)'g', (byte)'o' };
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddFAGBinaryRequest GetExamples()
        {
            return new AddFAGBinaryRequest
            {
                Data =  byteArray,
                FileName = "/dst/icon_03.png"
            };
        }
    }
}



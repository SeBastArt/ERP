using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.API.Extensions.Swagger.SwaggerExamples.Requests.FAGText
{
    /// <summary>
    /// EditFAGTextRequestExample
    /// </summary>
    public class EditFAGTextRequestExample : IExamplesProvider<EditFAGTextRequest>
    {
        /// <summary>
        /// GetExamples
        /// </summary>
        /// <returns>EditFAGTextRequest</returns>
        public EditFAGTextRequest GetExamples()
        {
            return new EditFAGTextRequest
            {
                Id = Guid.Parse("431e4290-49ad-4139-964d-c51d989c2fb5"),
                Text = "This line is the default color This line is red This line is the default color",
                TextRTF = "{\rtf1\ansi\\deff0{\\colortbl;\red0\\green0\\blue0;\\red255\\green0\\blue0;}This line is the default color\\line\\cf2This line is red\\line\\cf1This line is the default color}",
                Iso2cc = "de",
                Iso3cc = "deu"
            };
        }
    }
}

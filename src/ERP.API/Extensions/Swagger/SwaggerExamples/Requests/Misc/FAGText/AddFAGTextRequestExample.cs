using ERP.Domain.Models;
using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddCompanyRequestExample
    /// </summary>
    public class AddFAGTextRequestExample : IExamplesProvider<AddFAGTextRequest>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddFAGTextRequest GetExamples()
        {
            return new AddFAGTextRequest
            {
                Text = "This line is the default color This line is red This line is the default color",
                TextRTF = "{\rtf1\ansi\\deff0{\\colortbl;\red0\\green0\\blue0;\\red255\\green0\\blue0;}This line is the default color\\line\\cf2This line is red\\line\\cf1This line is the default color}",
                Iso2cc = "de",
                Iso3cc = "deu"
            };
        }
    }
}



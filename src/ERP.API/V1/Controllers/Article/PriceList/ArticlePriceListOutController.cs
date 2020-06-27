using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.API.Filters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.API.V1.Controllers.Article.PriceList
{
    [Produces("application/json")]
    [Route("api/article/pricelistsout")]
    [ApiController]
    [ApiVersion("1.0")]
    [JsonException]
    public class ArticlePriceListOutController : ControllerBase
    {
        // GET: api/<ArticlePriceListOutController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArticlePriceListOutController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArticlePriceListOutController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticlePriceListOutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticlePriceListOutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

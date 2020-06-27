using Newtonsoft.Json;
using RiskFirst.Hateoas.Models;
using System.Collections.Generic;

namespace ERP.Domain.Responses
{
    /// <summary>
    /// ItemHateoasResponse
    /// </summary>
    public class HateoasResponse<T> : ILinkContainer
    {
        public T Data;
        private Dictionary<string, Link> _links;

        [JsonProperty(PropertyName = "_links")]
        public Dictionary<string, Link> Links
        {
            get => _links ??= new Dictionary<string, Link>();
            set => _links = value;
        }

        /// <summary>
        /// AddLink
        /// </summary>
        /// <param name="id"></param>
        /// <param name="link"></param>
        public void AddLink(string id, Link link)
        {
            Links.Add(id, link);
        }
    }
}

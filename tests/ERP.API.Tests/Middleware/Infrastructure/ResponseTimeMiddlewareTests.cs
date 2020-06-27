using ERP.Fixtures;
using Shouldly;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace ERP.API.Tests.Middleware.Infrastructure
{
    public class ResponseTimeMiddlewareTests : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private readonly InMemoryWebApplicationFactory<Startup> _factory;

        private void AddAuthToken(ref HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1haWxAbWUuZGUiLCJuYW1laWQiOiIzMjhmMzZiYi04OTNhLTQ5ODItODhjYS0wZWE2NmNkNmFlMDUiLCJuYmYiOjE1OTE5NTM0MzUsImV4cCI6MTU5MjU1ODIzNSwiaWF0IjoxNTkxOTUzNDM1fQ.eRdNdCLlsIMxEsm8iG88VZV2sf8thyqkvFaJVWITQx4");
        }

        public ResponseTimeMiddlewareTests(InMemoryWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/items/?pageSize=1&pageIndex=0&api-version=1.0")]
        [InlineData("/api/artist/?pageSize=1&pageIndex=0&api-version=1.0")]
        [InlineData("/api/genre/?pageSize=1&pageIndex=0&api-version=1.0")]
        public async Task middleware_should_set_the_correct_response_time_custom_header(string url)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            response.Headers.GetValues("X-Response-Time-ms").ShouldNotBeEmpty();
        }
    }
}

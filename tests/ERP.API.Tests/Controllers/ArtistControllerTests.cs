using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Fixtures;
using Newtonsoft.Json;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ERP.API.Tests.Controllers
{
    public class ArtistControllerTests : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        public ArtistControllerTests(InMemoryWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        private readonly InMemoryWebApplicationFactory<Startup> _factory;

        [Theory]
        [InlineData("/api/artist?api-version=1.0")]
        public async Task Smoke_test_on_items(string url)

        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/api/artist/?pageSize=1&pageIndex=0&api-version=1.0", 1, 0)]
        public async Task Get_should_returns_paginated_data(string url, int pageSize, int pageIndex)

        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResult<GenreResponse> responseEntity =
                JsonConvert.DeserializeObject<ApiResult<GenreResponse>>(responseContent);

            responseEntity.PageIndex.ShouldBe(pageIndex);
            responseEntity.PageSize.ShouldBe(pageSize);
            responseEntity.Data.Count().ShouldBe(pageSize);
        }

        [Theory]
        [LoadData("artist")]
        public async Task Get_by_id_should_return_the_data(Artist request)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync($"/api/artist/{request.ArtistId}?api-version=1.0");

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            Artist responseEntity = JsonConvert.DeserializeObject<Artist>(responseContent);

            responseEntity.ArtistId.ShouldBe(request.ArtistId);
        }

        [Theory]
        [LoadData("artist")]
        public async Task Get_item_by_artist_should_return_the_artist(Artist request)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync($"/api/artist/{request.ArtistId}/items?api-version=1.0");

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            List<ItemResponse> responseEntity = JsonConvert.DeserializeObject<List<ItemResponse>>(responseContent);

            responseEntity.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Add_should_create_new_artist()
        {
            AddArtistRequest addArtistRequest = new AddArtistRequest { ArtistName = "The Braze" };

            HttpClient client = _factory.CreateClient();

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(addArtistRequest), Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/artist?api-version=1.0", httpContent);

            response.EnsureSuccessStatusCode();

            System.Uri responseHeader = response.Headers.Location;

            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            responseHeader.ToString().ShouldContain("/api/artist/");
        }
    }
}

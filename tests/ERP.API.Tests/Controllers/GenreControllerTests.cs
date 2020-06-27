using ERP.Domain.Models;
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
    public class GenreControllerTests : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        public GenreControllerTests(InMemoryWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        private readonly InMemoryWebApplicationFactory<Startup> _factory;

        [Theory]
        [InlineData("/api/genre?api-version=1.0")]
        public async Task Smoke_test_on_items(string url)

        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/api/genre/?pageSize=1&pageIndex=0&api-version=1.0", 1, 0)]
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
        [LoadData("genre")]
        public async Task Get_by_id_should_return_the_data(Genre request)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync($"/api/genre/{request.GenreId}?api-version=1.0");

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            Genre responseEntity = JsonConvert.DeserializeObject<Genre>(responseContent);

            responseEntity.GenreId.ShouldBe(request.GenreId);
            responseEntity.GenreDescription.ShouldBe(request.GenreDescription);
        }


        [Theory]
        [LoadData("genre")]
        public async Task Get_item_by_genre_should_return_the_data(Genre request)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync($"/api/genre/{request.GenreId}/items?api-version=1.0");

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            List<ItemResponse> responseEntity = JsonConvert.DeserializeObject<List<ItemResponse>>(responseContent);

            responseEntity.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Add_should_create_new_genre()
        {
            var genreDescription = new { GenreDescription = "Jazz" };
            HttpClient client = _factory.CreateClient();

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(genreDescription), Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/genre?api-version=1.0", httpContent);

            response.EnsureSuccessStatusCode();

            System.Uri responseHeader = response.Headers.Location;

            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            responseHeader.ToString().ShouldContain("/api/genre/");
        }
    }
}

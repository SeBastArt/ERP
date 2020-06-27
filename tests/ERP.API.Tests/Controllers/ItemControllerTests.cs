using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Fixtures;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;



namespace ERP.API.Tests
{
    public class ItemControllerTests : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private readonly InMemoryWebApplicationFactory<Startup> _factory;

        private void AddAuthToken(ref HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1haWxAbWUuZGUiLCJuYW1laWQiOiIzMjhmMzZiYi04OTNhLTQ5ODItODhjYS0wZWE2NmNkNmFlMDUiLCJuYmYiOjE1OTE5NTM0MzUsImV4cCI6MTU5MjU1ODIzNSwiaWF0IjoxNTkxOTUzNDM1fQ.eRdNdCLlsIMxEsm8iG88VZV2sf8thyqkvFaJVWITQx4");
        }

        public ItemControllerTests(InMemoryWebApplicationFactory<Startup> factory, ITestOutputHelper outputHelper)
        {
            _factory = factory;
            //now we get detailed error messages every time the test throw an error
            _factory.SetTestOutputHelper(outputHelper);
        }

        [Theory]
        [InlineData("/api/items/?pageSize=1&pageIndex=0&api-version=1.0", 1, 0)]
        [InlineData("/api/items/?pageSize=2&pageIndex=0&api-version=1.0", 2, 0)]
        [InlineData("/api/items/?pageSize=1&pageIndex=1&api-version=1.0", 1, 1)]
        public async Task Get_should_return_paginated_data(string url, int pageSize, int pageIndex)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResult<ItemResponse> responseEntity =
                JsonConvert.DeserializeObject<ApiResult<ItemResponse>>(responseContent);

            responseEntity.PageIndex.ShouldBe(pageIndex);
            responseEntity.PageSize.ShouldBe(pageSize);
            responseEntity.Data.Count().ShouldBe(pageSize);
        }

        [Theory]
        [LoadData("item")]
        public async Task Get_by_id_should_return_the_data(Item request)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            HttpResponseMessage response = await client.GetAsync($"/api/items/{request.Id}?api-version=1.0");

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ItemResponse responseEntity = JsonConvert.DeserializeObject<ItemResponse>(responseContent);

            responseEntity.Name.ShouldBe(request.Name);
            responseEntity.Description.ShouldBe(request.Description);
            responseEntity.Price.Amount.ShouldBe(request.Price.Amount);
            responseEntity.Price.Currency.ShouldBe(request.Price.Currency);
            responseEntity.Format.ShouldBe(request.Format);
            responseEntity.PictureUri.ShouldBe(request.PictureUri);
            responseEntity.GenreId.ShouldBe(request.GenreId);
            responseEntity.ArtistId.ShouldBe(request.ArtistId);
        }

        [Theory]
        [LoadData("item")]
        public async Task Add_should_create_new_record(AddItemRequest request)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"/api/items?api-version=1.0", httpContent);
            response.EnsureSuccessStatusCode();
            response.Headers.Location.ShouldNotBeNull();
        }

        [Theory]
        [LoadData("item")]
        public async Task Add_should_returns_bad_request_if_artistid_not_exist(AddItemRequest request)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            request.ArtistId = Guid.NewGuid();
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"/api/items?api-version=1.0", httpContent);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Theory]
        [LoadData("item")]
        public async Task Add_should_returns_bad_request_if_genreid_not_exist(AddItemRequest request)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            request.GenreId = Guid.NewGuid();
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"/api/items?api-version=1.0", httpContent);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Theory]
        [LoadData("item")]
        public async Task Update_should_modify_existing_items(EditItemRequest request)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"/api/items/{request.Id}?api-version=1.0", httpContent);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            RespContainer<ItemResponse> responseEntity = JsonConvert.DeserializeObject<RespContainer<ItemResponse>>(responseContent);

            responseEntity.Error.ShouldBeFalse();
            responseEntity.Data.Name.ShouldBe(request.Name);
            responseEntity.Data.Description.ShouldBe(request.Description);
            responseEntity.Data.Format.ShouldBe(request.Format);
            responseEntity.Data.PictureUri.ShouldBe(request.PictureUri);
            responseEntity.Data.GenreId.ShouldBe(request.GenreId);
            responseEntity.Data.ArtistId.ShouldBe(request.ArtistId);
        }

        [Theory]
        [LoadData("item")]
        public async Task Update_should_returns_not_found_when_item_is_not_present(EditItemRequest request)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"/api/items/{Guid.NewGuid()}?api-version=1.0", httpContent);

            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }


        [Theory]
        [LoadData("item")]
        public async Task Update_should_returns_not_found_if_artistid_not_exist(EditItemRequest request)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            request.ArtistId = Guid.NewGuid();
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"/api/items/{request.Id}?api-version=1.0", httpContent);

            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Theory]
        [LoadData("item")]
        public async Task Update_should_returns_not_found_if_genreid_not_exist(EditItemRequest request)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            request.GenreId = Guid.NewGuid();
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"/api/items/{request.Id}?api-version=1.0", httpContent);

            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Theory]
        [LoadData("item")]
        public async Task Delete_should_returns_ok_when_called_with_right_id(DeleteItemRequest request)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            HttpResponseMessage response = await client.DeleteAsync($"/api/items/{request.Id}?api-version=1.0");
            string responseContent = await response.Content.ReadAsStringAsync();
            RespContainer<ItemResponse> responseEntity = JsonConvert.DeserializeObject<RespContainer<ItemResponse>>(responseContent);

            responseEntity.Error.ShouldBeFalse();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Delete_should_returns_not_found_when_called_with_not_existing_id()
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            HttpResponseMessage response = await client.DeleteAsync($"/api/items/{Guid.NewGuid()}?api-version=1.0");

            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Getbyid_should_returns_not_found_when_item_is_not_present()
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            HttpResponseMessage response = await client.GetAsync($"/api/items/{Guid.NewGuid()}?api-version=1.0");

            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}

using ERP.Domain.Requests.User;
using ERP.Domain.Responses;
using ERP.Domain.Responses.User;
using ERP.Fixtures;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ERP.API.Tests.Controllers
{
    public class UserControllerTests : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private readonly InMemoryWebApplicationFactory<Startup> _factory;

        private void AddAuthToken(ref HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1haWxAbWUuZGUiLCJuYW1laWQiOiIzMjhmMzZiYi04OTNhLTQ5ODItODhjYS0wZWE2NmNkNmFlMDUiLCJuYmYiOjE1OTE5NTM0MzUsImV4cCI6MTU5MjU1ODIzNSwiaWF0IjoxNTkxOTUzNDM1fQ.eRdNdCLlsIMxEsm8iG88VZV2sf8thyqkvFaJVWITQx4");
        }

        public UserControllerTests(InMemoryWebApplicationFactory<Startup> factory, ITestOutputHelper outputHelper)
        {
            _factory = factory;
            _factory.SetTestOutputHelper(outputHelper);
        }

        [Theory]
        [InlineData("/api/user/auth?api-version=1.0")]
        public async Task Sign_in_should_retrieve_a_token(string url)
        {
            HttpClient client = _factory.CreateClient();

            SignInRequest request = new SignInRequest { Email = "samuele.resca@example.com", Password = "P@$$w0rd" };
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, httpContent);
            string responseContent = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseContent.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData("/api/user/auth?api-version=1.0")]
        public async Task Sign_in_should_retrieve_bad_request_with_invalid_password(string url)
        {
            HttpClient client = _factory.CreateClient();

            SignInRequest request = new SignInRequest { Email = "samuele.resca@example.com", Password = "NotValidPWD" };
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, httpContent);
            string responseContent = await response.Content.ReadAsStringAsync();

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            responseContent.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData("/api/user")]
        public async Task Get_with_authorized_user_should_retrieve_the_right_user(string url)
        {
            HttpClient client = _factory.CreateClient();

            SignInRequest signInRequest = new SignInRequest { Email = "samuele.resca@example.com", Password = "P@$$w0rd" };
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(signInRequest), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url + "/auth?api-version=1.0", httpContent);
            string responseContent = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            RespContainer<TokenResponse> tokenResponse = JsonConvert.DeserializeObject<RespContainer<TokenResponse>>(responseContent);

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", tokenResponse.Data.Token);

            HttpResponseMessage restrictedResponse = await client.GetAsync(url + "?api-version=1.0");

            restrictedResponse.EnsureSuccessStatusCode();
            restrictedResponse.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/api/user?api-version=1.0")]
        public async Task Post_should_create_a_new_user(string url)
        {
            HttpClient client = _factory.CreateClient();
            AddAuthToken(ref client);
            SignUpRequest signUpRequest = new SignUpRequest()
            {
                Email = "samuele@example.com",
                Password = "P@$$w0rd",
                FirstName = "Samuele",
                LastName = "Resca"
            };
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(signUpRequest), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBe("http://localhost/api/user");
        }
    }
}
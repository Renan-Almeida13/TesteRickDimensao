using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RickDimensao.Domain.Entities;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteRickDimensao;
using Xunit;
using TheoryAttribute = Xunit.TheoryAttribute;

namespace RickDimensao.Testes
{
    public class RickTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public RickTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Rick/GetRick")]
        [InlineData("/api/Rick/GetRickById/1")]
        public async Task GetHttpRequest(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                    response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/Rick/PostRick")]
        public async Task PostHttpRequest(string url)
        {
            Rick rick = new Rick();

            var stringContent = new StringContent(JsonConvert.SerializeObject(rick), Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            var result = await client.PostAsync(url, stringContent, CancellationToken.None);

            result.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                    result.Content.Headers.ContentType.ToString());

        }

        [Theory]
        [InlineData("/api/Rick/DeleteRick?id=10")]
        public async Task DeleteHttpRequest(string url)
        {
            var client = _factory.CreateClient();

            var result = await client.DeleteAsync(url);

            result.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                    result.Content.Headers.ContentType.ToString());

        }

        [Theory]
        [InlineData("/api/Rick/UpdateRick")]
        public async Task UpdateHttpRequest(string url)
        {
            Rick rick = new Rick();

            var stringContent = new StringContent(JsonConvert.SerializeObject(rick), Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            var result = await client.PutAsync(url, stringContent, CancellationToken.None);

            result.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                    result.Content.Headers.ContentType.ToString());

        }
    }
}

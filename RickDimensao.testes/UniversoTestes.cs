using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RickDimensao.Domain.Entities;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteRickDimensao;
using Xunit;

namespace RickLocalization.Tests
{
    public class UniversoTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UniversoTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Dimensao/GetDimensao")]
        [InlineData("/api/Dimensao/GetDimensaoById/1")]
        [InlineData("/api/Dimensao/GetHistoricoDimensaoRick/1")]
        public async Task GetHttpRequest(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                    response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/Dimensao/PostDimensao")]
        public async Task PostHttpRequest(string url)
        {
            Universo universo = new Universo();

            var stringContent = new StringContent(JsonConvert.SerializeObject(universo), Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            var result = await client.PostAsync(url, stringContent, CancellationToken.None);

            result.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                    result.Content.Headers.ContentType.ToString());

        }

        [Theory]
        [InlineData("/api/Dimensao/DeleteDimensao?id=13")]
        public async Task DeleteHttpRequest(string url)
        {
            var client = _factory.CreateClient();

            var result = await client.DeleteAsync(url);

            result.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                    result.Content.Headers.ContentType.ToString());

        }

        [Theory]
        [InlineData("/api/Dimensao/UpdateDimensao")]
        public async Task UpdateHttpRequest(string url)
        {
            Universo universo = new Universo();

            var stringContent = new StringContent(JsonConvert.SerializeObject(universo), Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            var result = await client.PutAsync(url, stringContent, CancellationToken.None);

            result.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                    result.Content.Headers.ContentType.ToString());

        }
    }
}

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MovieBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.IntegrationTests
{
    public class IntegrationTest
    {
        private readonly HttpClient _testClient;
        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(MovieBaseDbContext));
                        services.AddDbContext<MovieBaseDbContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });
            _testClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            _testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer ", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            //var response = _testClient.PostAsJsonAsync("")
            return null;
        }
    }
}

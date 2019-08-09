using System;
using Xunit;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;


namespace AntilopaApi.Test
{
    public class CarsEndpoints : IClassFixture<WebApplicationFactory<AntilopaApi.Startup>>
    {
        private readonly WebApplicationFactory<AntilopaApi.Startup> _factory;

        public CarsEndpoints(WebApplicationFactory<AntilopaApi.Startup> factory)
        {
            _factory = factory;
        }
    
        [Fact]
        public async Task GetCarsReturnSuccessAndCorrectContentType()
        {            
            var client = _factory.CreateClient();         
            var response = await client.GetAsync("/api/cars/");
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }        
    }
}

using Contract;
using Contract.Helpers;
using Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Persistence.Repository;
using Service;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Web.Middleware;
using Xunit;

namespace Test.MiddleWare
{
    public class ExceptionHandlingMiddlewareTests
    {

        [Fact]
        public async Task ExceptionHandlingMiddlewareTests_WhenNoErrors_ShouldReturnOk()
        {
            using var host = await new HostBuilder()
        .ConfigureWebHost(webBuilder =>
        {
            webBuilder
                .UseTestServer()
                .ConfigureServices(services =>
                {
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                    services.AddScoped<IHelper, Helper>();


                    services.AddScoped<IDriverService, DriverService>();

                    services.AddScoped<IDriverRepository, DriverRepository>();

                    services.AddTransient<ExceptionHandlingMiddleware>();
                })
                .Configure(app =>
                {
                    app.UseMiddleware<ExceptionHandlingMiddleware>();
                });
        })
        .StartAsync();

            var response = await host.GetTestClient().GetAsync("/api/drivers/getAllDrivers");

            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
        }

        
    }
}

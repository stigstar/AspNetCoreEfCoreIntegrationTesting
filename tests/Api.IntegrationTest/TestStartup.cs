using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.IntegrationTest
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void ConfigureDatabase(IServiceCollection services)
        {
            var databaseName = "My";
            services.AddDbContext<MyContext>(o =>
                o.UseInMemoryDatabase(databaseName));
        }
    }
}
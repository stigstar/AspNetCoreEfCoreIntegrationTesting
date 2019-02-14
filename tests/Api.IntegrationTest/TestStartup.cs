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
            const string databaseName = "My";
            services.AddDbContext<MyContext>(o => o.UseInMemoryDatabase(databaseName));
        }
    }
}
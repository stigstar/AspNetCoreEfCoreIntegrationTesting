using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.IntegrationTest
{
    public class TestStartup : Startup
    {
        protected override void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(o => o.UseInMemoryDatabase("MyDatabaseName"));
        }
    }
}
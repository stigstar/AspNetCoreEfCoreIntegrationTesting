using System.Net.Http;
using System.Threading.Tasks;
using Data;
using Data.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;


namespace Api.IntegrationTest
{
    [TestClass]
    public class ValuesControllerTest
    {
        public HttpClient Client { get; set; }
        public TestServer Server { get; set; }
        public MyContext Context { get; set; }


        [TestInitialize]
        public void Init()
        {
            var webHostBuilder = WebHost
                .CreateDefaultBuilder()
                .UseStartup<TestStartup>();

            Server = new TestServer(webHostBuilder);
            Client = Server.CreateClient();
            Context = Server.Host.Services.GetRequiredService<MyContext>();
        }


        [TestMethod]
        public async Task TestMethod1()
        {
            //arrange
            await Context.AddAsync(new Value { Id = 1, Epicness = 1337 }).ConfigureAwait(false);
            await Context.SaveChangesAsync();


            //act
            var result = await Client.GetAsync("/values/1");

            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();

            
            //var deserializedResult = JsonConvert.DeserializeObject<Value>(await result.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual("", content);
        }
    }
}

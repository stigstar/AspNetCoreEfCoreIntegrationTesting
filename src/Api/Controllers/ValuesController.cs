using System.Threading.Tasks;
using Data;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        private readonly MyContext _myContext;

        public ValuesController(MyContext myContext)
        {
            _myContext = myContext;
        }

        [HttpGet("{id}")]
        public async Task<Value> GetValue(int id)
        {
            var value = _myContext.Values.FirstOrDefaultAsync().Result;
            return value;
        }
    }
}
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyContext _myContext;

        public ValuesController(MyContext myContext)
        {
            _myContext = myContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _myContext.Values.FirstOrDefaultAsync(x => x.Id == id));
        }    
    }
}
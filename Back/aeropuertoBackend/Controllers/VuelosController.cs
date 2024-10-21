using aeropuertoBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aeropuertoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        // GET: api/<VuelosController>
        mydbContext dbContext = new mydbContext();

        [HttpGet]
        public IEnumerable<Vuelo> Get()
        {
            return dbContext.Vuelos.ToList();
        }

        // GET api/<VuelosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VuelosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VuelosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VuelosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

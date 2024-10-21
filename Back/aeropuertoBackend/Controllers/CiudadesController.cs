using aeropuertoBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aeropuertoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadesController : ControllerBase
    {
        mydbContext dbContext = new mydbContext();

        // GET: api/<CiudadesController>
        [HttpGet]
        public IEnumerable<Ciudade> Get()
        {
            return dbContext.Ciudades.ToList();
        }

        // GET api/<CiudadesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CiudadesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CiudadesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CiudadesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

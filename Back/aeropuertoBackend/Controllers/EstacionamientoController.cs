using aeropuertoBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aeropuertoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionamientoController : ControllerBase
    {

        mydbContext dbContext = new mydbContext();
        // GET: api/<EstacionamientoController>
        [HttpGet]
        public IEnumerable<Estacionamiento> Get()
        {
            return dbContext.Estacionamientos.ToList();
        }

        // GET api/<EstacionamientoController>/5
        [HttpGet("{id}")]
        public Estacionamiento Get(int id)
        {
            return dbContext.Estacionamientos.FirstOrDefault(e => e.IdEstacionamiento == id);
        }
        

        // POST api/<EstacionamientoController>
        [HttpPost]
        public void Post([FromBody] Estacionamiento value)
        {
            dbContext.Estacionamientos.Add(value);
            dbContext.SaveChanges();
        }

        [HttpPut]
        public void Put(Estacionamiento value) { 
            dbContext.Estacionamientos.Update(value);
            dbContext.SaveChanges();
        }


        // DELETE api/<EstacionamientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbContext.Estacionamientos.Remove(Get(id));
        }
    }
}

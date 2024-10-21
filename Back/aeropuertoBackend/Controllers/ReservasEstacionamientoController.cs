using aeropuertoBackend.dataObjects;
using aeropuertoBackend.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aeropuertoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasEstacionamientoController : ControllerBase
    {
        // GET: api/<ReservasEstacionamientoController>
        mydbContext dbContext = new mydbContext();

        [HttpGet]
        public IEnumerable<Reservasestacionamiento> Get()
        {
            return dbContext.Reservasestacionamientos.ToList();
        }

        // GET api/<ReservasEstacionamientoController>/5
        [HttpGet("{id}")]
        public Reservasestacionamiento Get(int id)
        {
            return dbContext.Reservasestacionamientos.FirstOrDefault(e => e.IdReservasEstacionamiento == id);
        }

        [HttpGet("Usuario/{id}")]
        public IActionResult GetByUser(int id) {
            return Ok(dbContext.Reservasestacionamientos.Where(e => e.IdUsuario == id).ToList());

        }


        // POST api/<ReservasEstacionamientoController>
        [HttpPost]
        public void Post([FromBody] ReservasestacionamientoDTO value)
        {

            Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Reservasestacionamiento, ReservasestacionamientoDTO>().ReverseMap()));



            dbContext.Reservasestacionamientos.Add(mapper.Map<Reservasestacionamiento>(value));
            dbContext.SaveChanges();

        }

        // PUT api/<ReservasEstacionamientoController>/5
        [HttpPut("{id}")]
        public void Put(Reservasestacionamiento value)
        {
            dbContext.Reservasestacionamientos.Update(value);
            dbContext.SaveChanges();

        }

        // DELETE api/<ReservasEstacionamientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbContext.Reservasestacionamientos.Remove(Get(id));
            dbContext.SaveChanges();
        }
    }
}

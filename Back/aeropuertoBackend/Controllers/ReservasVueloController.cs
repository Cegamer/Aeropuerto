using aeropuertoBackend.dataObjects;
using aeropuertoBackend.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aeropuertoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasVueloController : ControllerBase
    {
        mydbContext dbContext = new mydbContext();

        [HttpGet]
        public IEnumerable<Reservasvuelo> Get()
        {
            return dbContext.Reservasvuelos.ToList();
        }

        // GET api/<ReservasVueloController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("Usuario/{id}")]
        public IActionResult GetByUser(int id)

        {
            
            var reservas = from reserva in dbContext.Reservasvuelos
                           where reserva.IdUsuario == id
                           join vuelo in dbContext.Vuelos on reserva.IdVuelo equals vuelo.IdVuelos
                           join ciudadOrigen in dbContext.Ciudades on vuelo.Origen equals ciudadOrigen.IdCiudad
                           join ciudadDestino in dbContext.Ciudades on vuelo.Destino equals ciudadDestino.IdCiudad
                           select new
                           {
                               reserva.IdReservasVuelo,
                               vuelo.HoraSalida,
                               vuelo.HoraLlegada,
                               CiudadOrigen = ciudadOrigen.NombreCiudad,
                               CiudadDestino = ciudadDestino.NombreCiudad,
                               reserva.TipoAsiento,
                               vuelo.FechaSalida
                           };

            var listaReservas = reservas.ToList();

            return Ok(listaReservas);

        }


        // POST api/<ReservasVueloController>
        [HttpPost]
        public void Post([FromBody] ReservasVueloDTO value)
        {
            Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ReservasVueloDTO, Reservasvuelo>().ReverseMap()));

            var incidencia = mapper.Map<Reservasvuelo>(value);

            dbContext.Reservasvuelos.Add(incidencia);
            dbContext.SaveChanges();
        }

        // PUT api/<ReservasVueloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservasVueloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

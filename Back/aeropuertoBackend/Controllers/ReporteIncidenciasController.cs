using aeropuertoBackend.dataObjects;
using aeropuertoBackend.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aeropuertoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteIncidenciasController : ControllerBase
    {

        mydbContext dbContext = new mydbContext();
        // GET: api/<EstacionamientoController>
        [HttpGet]
        public IEnumerable<Reporteincidencia> Get()
        {
            return dbContext.Reporteincidencias.ToList();
        }

        // GET api/<EstacionamientoController>/5
        [HttpGet("{id}")]
        public Reporteincidencia Get(int id)
        {
            return dbContext.Reporteincidencias.FirstOrDefault(e => e.IdreporteIncidencias == id);
        }
        [HttpGet("Usuario/{id}")]
        public IActionResult GetByUser(int id)
        {
            return Ok(dbContext.Reporteincidencias.Where(e => e.IdUsuarioReporto == id).ToList());

        }


        [HttpPost]
        public void Post([FromBody] ReporteincidenciaDTO value)
        {
            Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Reporteincidencia, ReporteincidenciaDTO>().ReverseMap()));

            var incidencia = mapper.Map<Reporteincidencia>(value); 

            dbContext.Reporteincidencias.Add(incidencia);
            dbContext.SaveChanges();
        }

        [HttpPut]
        public void Put(Reporteincidencia value)
        {
            dbContext.Reporteincidencias.Update(value);
            dbContext.SaveChanges();
        }


        // DELETE api/<EstacionamientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbContext.Reporteincidencias.Remove(Get(id));
            dbContext.SaveChanges();

        }
    }
}

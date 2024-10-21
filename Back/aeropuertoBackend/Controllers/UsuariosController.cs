using aeropuertoBackend.dataObjects;
using aeropuertoBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aeropuertoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/<UsuariosController>
        mydbContext dbContext = new mydbContext();

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return dbContext.Usuarios.ToList();
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return dbContext.Usuarios.FirstOrDefault(u => u.IdUsuarios == id);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario value)
        {
            var usuarioExistente = dbContext.Usuarios.FirstOrDefault(u => u.Correo == value.Correo);

            if (usuarioExistente == null)
            {
                Usuario usuarioRegistrado = dbContext.Usuarios.Add(value).Entity;
                dbContext.SaveChanges();

                return Ok(usuarioRegistrado.IdUsuarios);
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Post([FromBody] LoginInfo login)
        {
            var usuario = dbContext.Usuarios.FirstOrDefault(u => u.Correo == login.email && u.Password == login.password);
            if(usuario != null)
                return Ok(usuario);
            return BadRequest();
        }


        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario value)
        {
            dbContext.Usuarios.Update(value);
            dbContext.SaveChanges();
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbContext.Usuarios.Remove(Get(id));
            dbContext.SaveChanges();
        }
    }
}

using API_Clima.Context;
using API_Clima.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Clima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ConsultasController(AppDbContext context)
        {
            this._context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Consulta> Get()
        {
            return _context.Consultas.ToList();
        }

        // GET api/<ValuesController>/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{nombre}")]
        public IEnumerable<Consulta> Get(string nombre)
        {
            var Consulta = _context.Consultas.Where(x => x.Nombre == nombre).ToList();
            return Consulta ;
        }

        // POST api/<ValuesController>
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public ActionResult Post([FromBody] Consulta consulta)
        {
            try
            {
                consulta.Fecha = DateTime.Now;
                if (_context.Consultas.Any(x=>x.Nombre == consulta.Nombre))
                {
                   // var ayuda = _context.Consultas.Where(x => x.Nombre == consulta.Nombre).FirstOrDefault();
                   // consulta.id = ayuda.id;
                    _context.Consultas.Update(consulta);
                }
                else
                {
                    _context.Consultas.Add(consulta);
                }
              
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
          
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{nombre}")]
        public void Put(string nombre, [FromBody] Consulta consulta)
        {

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

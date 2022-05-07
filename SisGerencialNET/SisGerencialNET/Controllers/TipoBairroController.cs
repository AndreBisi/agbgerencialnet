using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers.Data
{
    [ApiController]
    [Route("[controller]")]
    public class TipoBairroController : ControllerBase
    {
        private Context _context;

        public TipoBairroController()
        {
            _context = new Context();
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.TiposBairro);
        }

        [HttpGet("{id}")]
        public IActionResult getPorId(int id)
        {
            TipoBairro tipoBairro = _context.TiposBairro.FirstOrDefault(tipoBairro => tipoBairro.Id == id);
            if (tipoBairro != null) return Ok(tipoBairro);
            return NotFound();
        }

        [HttpPost]
        public IActionResult post([FromBody] TipoBairro tipoBairro)
        {
            _context.TiposBairro.Add(tipoBairro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getPorId), new { Id = tipoBairro.Id }, tipoBairro);

        }

        [HttpPut]
        public IActionResult put(int id, [FromBody] TipoBairro tipoBairro)
        {
            TipoBairro tipoBairro2 = _context.TiposBairro.FirstOrDefault(t => t.Id == id);
            if(tipoBairro2 == null)
            {
                return NotFound();
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}

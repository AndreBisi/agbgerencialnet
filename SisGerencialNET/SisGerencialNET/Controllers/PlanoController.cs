using Microsoft.AspNetCore.Mvc;
using SisGerencialNET.Controllers.Data;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanoController : ControllerBase
    {
        private PlanoContext _context;

        public PlanoController()
        {
            _context = new PlanoContext();
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.Planos);
        }

        [HttpGet("{id}")]
        public IActionResult getPorId( int id )
        {
            Plano plano = _context.Planos.FirstOrDefault(plano => plano.Id == id);
            if (plano != null) return Ok(plano);
            return NotFound();
        }
    }
}
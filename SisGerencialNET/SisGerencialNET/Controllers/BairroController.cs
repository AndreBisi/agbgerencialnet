using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Controllers.Data;

namespace SisGerencialNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BairroController : ControllerBase
    {
        private BairroContext _context;

        public BairroController()
        {
            _context = new BairroContext();
        }

        [HttpGet]
        public IActionResult get()
        {
            /*var bairros = _context.Bairros
                .Include(i => i.TipoBairro);*/

            /*var tiposBairro = new TipoBairroContext();

            var tiposBairro2 = tiposBairro.TiposBairro
                .Include(a => a.BairroList);
                
            return Ok(tiposBairro2);*/

            return Ok(_context.Bairros);
        }
    }
}

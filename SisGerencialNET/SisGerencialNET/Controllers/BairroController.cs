using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Controllers.Data;

namespace SisGerencialNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BairroController : ControllerBase
    {
        private Context _context;

        public BairroController()
        {
            _context = new Context();
        }

        [HttpGet]
        public IActionResult get()
        {
            var contexto2 = _context.Bairros
            .Include(a => a.TipoBairro);

            return Ok(contexto2);
        }
    }
}

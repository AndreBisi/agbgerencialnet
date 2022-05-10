using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Controllers.Data;
using SisGerencialNET.Data.Dtos;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BairroController : ControllerBase
    {
        private Context _context;

        private IMapper _mapper;
        public BairroController( Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.Bairros);
        }

        [HttpPost]
        public IActionResult post([FromBody] Bairro bairro)
        {
            _context.Bairros.Add(bairro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getPorId), new { Id = bairro.Id }, bairro);

        }

        [HttpGet("{id}")]
        public IActionResult getPorId(int id)
        {

            Bairro bairro = _context.Bairros.FirstOrDefault(bairro => bairro.Id == id);
            if (bairro != null)
            {
                ReadBairroDto bairroDto = _mapper.Map<ReadBairroDto>(bairro);

                return Ok(bairroDto);
            }
            return NotFound();
        }
    }
}

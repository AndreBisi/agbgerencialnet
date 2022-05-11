using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Data.Dtos;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers.Data
{
    [ApiController]
    [Route("[controller]")]
    public class TipoBairroController : ControllerBase
    {
        private Context _context;
        private IMapper _mapper;

        public TipoBairroController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadTipoBairroDto ReadTipoBairroDto { get; private set; }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.TiposBairro);
        }

        [HttpGet("{id}")]
        public IActionResult getPorId(int id)
        {
            TipoBairro tipoBairro = _context.TiposBairro.FirstOrDefault(tipoBairro => tipoBairro.Id == id);
            if (tipoBairro != null)
            {
                ReadTipoBairroDto tipoBairroDto = _mapper.Map<ReadTipoBairroDto>(tipoBairro);

                return Ok(tipoBairroDto);
            }
            return NotFound();  
        }

        private IActionResult Ok(object tipoBairroDto)
        {
            throw new NotImplementedException();
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

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SisGerencialNET.Controllers.Data;
using SisGerencialNET.Data.Dtos;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanoController : ControllerBase
    {
        private Context _context;
        private IMapper _mapper;

        public PlanoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            if (plano != null)
            {
                ReadPlanoDto planoDto = _mapper.Map<ReadPlanoDto>(plano);

                return Ok(planoDto);
            }
            return NotFound();
        }
    }
}
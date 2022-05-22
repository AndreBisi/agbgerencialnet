using AutoMapper;
using DataBaseControl;
using Microsoft.AspNetCore.Mvc;
using SisGerencialNET.Data.Dtos;
using SisGerencialNET.Models;
using System.Data;

namespace SisGerencialNET.Controllers.Data
{
    [ApiController]
    [Route("[controller]")]
    public class TipoBairroController : ControllerBase
    {
        private Context _context;
        private IMapper _mapper;
        private DataBasePersistenceControl _control = new DataBasePersistenceControl();

        DataBaseConnection _conexao = new DataBaseConnection();

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
            DataTable tabela = _control.BuscaDados($"select * from tbTipoBairro where tipobairrocod = {id}");

            TipoBairro tipoBairro = new TipoBairro();

            tipoBairro.Id = Int32.Parse ( tabela.Rows[0]["tipobairrocod"].ToString() );
            tipoBairro.Nome = tabela.Rows[0]["tipobairronome"].ToString();
            tipoBairro.Abreviacao = tabela.Rows[0]["tipobairroabrev"].ToString();

            return Ok(tipoBairro);
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

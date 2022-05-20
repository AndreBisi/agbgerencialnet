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
        private IMapper _mapper;
        private DataBasePersistenceControl _control = new DataBasePersistenceControl();

        DataBaseConnection _conexao = new DataBaseConnection();

        public TipoBairroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ReadTipoBairroDto ReadTipoBairroDto { get; private set; }

        [HttpGet]
        public IActionResult get()
        {
            DataTable tabela = _control.BuscaDados($"select * from tbTipoBairro");

            IList<ReadTipoBairroDto> tiposDeBairro = new List<ReadTipoBairroDto>();

            var tipoBairro = new TipoBairro();
            foreach( DataRow tb in tabela.Rows )
            {
                tipoBairro.Id = Int32.Parse(tb["tipobairrocod"].ToString());
                tipoBairro.Nome = tb["tipobairronome"].ToString();
                tipoBairro.Abreviacao = tb["tipobairroabrev"].ToString();

                tiposDeBairro.Add(_mapper.Map<ReadTipoBairroDto>(tipoBairro));
            }

            return Ok(tiposDeBairro);
        }

        [HttpGet("{id}")]
        public IActionResult getPorId(int id)
        {
            DataTable tabela = _control.BuscaDados($"select * from tbTipoBairro where tipobairrocod = {id}");

            if(tabela.Rows.Count > 0)
            {
                TipoBairro tipoBairro = new TipoBairro();

                tipoBairro.Id = Int32.Parse(tabela.Rows[0]["tipobairrocod"].ToString());
                tipoBairro.Nome = tabela.Rows[0]["tipobairronome"].ToString();
                tipoBairro.Abreviacao = tabela.Rows[0]["tipobairroabrev"].ToString();

                ReadTipoBairroDto tipoBairroDto = _mapper.Map<ReadTipoBairroDto>(tipoBairro);

                return Ok(tipoBairroDto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult post([FromBody] TipoBairro tipoBairro)
        {
            //            _context.TiposBairro.Add(tipoBairro);
            //            _context.SaveChanges();
            //            return CreatedAtAction(nameof(getPorId), new { Id = tipoBairro.Id }, tipoBairro);
            return NotFound();

        }

        [HttpPut]
        public IActionResult put(int id, [FromBody] TipoBairro tipoBairro)
        {
            //           TipoBairro tipoBairro2 = _context.TiposBairro.FirstOrDefault(t => t.Id == id);
            //          if (tipoBairro2 == null)
            //         {
            //            return NotFound();
            //       }
            //      _context.SaveChanges();
            //     return NoContent();

            return NotFound();
        }
    }
}

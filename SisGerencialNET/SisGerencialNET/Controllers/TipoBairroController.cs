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

        private ReadTipoBairroDto PopulaObjeto( DataRow dataRow )
        {
            TipoBairro tipoBairro = new TipoBairro();

            tipoBairro.Id = Int32.Parse(dataRow["tipobairrocod"].ToString());
            tipoBairro.Nome = dataRow["tipobairronome"].ToString();
            tipoBairro.Abreviacao = dataRow["tipobairroabrev"].ToString();

            return _mapper.Map<ReadTipoBairroDto>(tipoBairro);
        }

        public ReadTipoBairroDto ReadTipoBairroDto { get; private set; }

        [HttpGet]
        public IActionResult Get()
        {
            DataTable tabela = _control.BuscaDados($"select * from tbTipoBairro");

            IList<ReadTipoBairroDto> tiposDeBairro = new List<ReadTipoBairroDto>();

            var tipoBairro = new TipoBairro();
            foreach( DataRow tb in tabela.Rows )
            {
                tiposDeBairro.Add(PopulaObjeto(tb));
            }
            return Ok(tiposDeBairro);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            DataTable tabela = _control.BuscaDados($"select * from tbTipoBairro where tipobairrocod = {id}");

            if(tabela.Rows.Count > 0)
            {
                return Ok(PopulaObjeto(tabela.Rows[0]));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] TipoBairro tipoBairro)
        {
            try
            {
                _control.PersisteDados($"insert into tbtipobairro(tipobairrocod, tipobairronome, tipobairroabrev) " +
                    $"values({tipoBairro.Id}, '{tipoBairro.Nome}', '{tipoBairro.Abreviacao}') ");

                return CreatedAtAction(nameof(GetPorId), new { Id = tipoBairro.Id }, tipoBairro);
            }
            catch (Exception ex)
            {
                try
                {
                    return NotFound(ex);
                }
                catch
                {
                    throw ex;
                }
            }
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] TipoBairro tipoBairro)
        {
            try
            {
                _control.PersisteDados($"UPDATE tbtipobairro set tipobairronome = '{tipoBairro.Nome}', " +
                    $"tipobairroabrev = '{tipoBairro.Abreviacao}' " +
                    $"where tipobairrocod = {tipoBairro.Id}");

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _control.PersisteDados($"DELETE from tbtipobairro where tipobairrocod = {id}");

                //se deletar
                return NoContent();

            }
            catch
            {
                //se não achar
                return NotFound();
            }
        }
    }
}

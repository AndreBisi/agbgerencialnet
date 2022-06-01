using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Controllers.Data;
using SisGerencialNET.Data.Dtos.BairroDto;
using SisGerencialNET.Models;
using System.Data;

namespace SisGerencialNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BairroController : ControllerBase
    {
        
        private IMapper _mapper;
        private DataBasePersistenceControl _control = new DataBasePersistenceControl();
        public ReadBairroDto ReadBairroDto { get; private set; }

        DataBaseConnection _conexao = new DataBaseConnection();

        public BairroController( Context context, IMapper mapper)
        {
            _mapper = mapper;
        }

        private ReadBairroDto PopulaObjeto(DataRow dataRow)
        {
            Bairro bairro = new Bairro();

            bairro.Id = Int32.Parse(dataRow["bairrocod"].ToString());
            bairro.Nome = dataRow["bairronome"].ToString();
            bairro.TipoBairro.Id = Int32.Parse( dataRow["tipobairrocod"].ToString() );
            bairro.TipoBairro.Nome = dataRow["tipobairronome"].ToString();
            bairro.TipoBairro.Abreviacao = dataRow["tipobairroabrev"].ToString();

            return _mapper.Map<ReadBairroDto>(bairro);
        }

        [HttpGet]
        public IActionResult get()
        {
            DataTable tabela = _control.BuscaDados($"select a.*, b.tipoBairroNome, b.tipoBairroAbrev from tbBairro a " +
                $"left join tbTipoBairro b on ( b.tipoBairroCod = a.tipoBairroCod )" );

            IList<ReadBairroDto> bairros = new List<ReadBairroDto>();

            var bairro = new Bairro();
            foreach (DataRow tb in tabela.Rows)
            {
                bairros.Add(PopulaObjeto(tb));
            }
            return Ok(bairros);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            DataTable tabela = _control.BuscaDados($"select a.*, b.tipoBairroNome, b.tipoBairroAbrev from tbBairro a " +
                $"left join tbTipoBairro b on ( b.tipoBairroCod = a.tipoBairroCod ) " +
                $"where a.bairrocod = {id}");

            if (tabela.Rows.Count > 0)
            {
                return Ok(PopulaObjeto(tabela.Rows[0]));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateBairroDto bairroDto)
        {
            try
            {
                Bairro bairro = _mapper.Map<Bairro>(bairroDto);

                _control.PersisteDados($"INSERT INTO tbbairro(tipocod, tiponome, tipobairrocod) " +
                    $"values({bairro.Id}, '{bairro.Nome}', '{bairro.TipoBairro.Id}') ");

                return CreatedAtAction(nameof(GetPorId), new { Id = bairro.Id }, bairro);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateBairroDto bairroDto)
        {
            try
            {
                Bairro bairro = _mapper.Map<Bairro>(bairroDto);

                _control.PersisteDados($"UPDATE tbbairro set bairronome = '{bairro.Nome}', " +
                    $"tipobairrocod = '{bairro.TipoBairro.Id}' " +
                    $"where bairrocod = {bairro.Id}");

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _control.PersisteDados($"DELETE FROM tbbairro where bairrocod = {id}");

                return NoContent();

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

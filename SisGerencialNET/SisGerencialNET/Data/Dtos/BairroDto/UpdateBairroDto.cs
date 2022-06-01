using SisGerencialNET.Data.Dtos.TipoBairroDto;
using System.ComponentModel.DataAnnotations;

namespace SisGerencialNET.Data.Dtos.BairroDto
{
    public class UpdateBairroDto
    {
        [Required(ErrorMessage = "O código é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        public ReadTipoBairroDto tipoBairro { get; set; }
    }
}

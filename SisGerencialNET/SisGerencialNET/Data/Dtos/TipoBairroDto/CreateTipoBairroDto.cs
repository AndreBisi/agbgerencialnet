using System.ComponentModel.DataAnnotations;

namespace SisGerencialNET.Data.Dtos.TipoBairroDto
{
    public class CreateTipoBairroDto
    {
        [Required(ErrorMessage = "O código é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        public string? Abreviacao { get; set; }

    }
}

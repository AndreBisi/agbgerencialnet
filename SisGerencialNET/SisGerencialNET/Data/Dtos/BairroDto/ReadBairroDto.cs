using SisGerencialNET.Models;

namespace SisGerencialNET.Data.Dtos.BairroDto
{
    public class ReadBairroDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoBairro TipoBairro { get; set; }
    }
}

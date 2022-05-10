using SisGerencialNET.Models;

namespace SisGerencialNET.Data.Dtos
{
    public class ReadBairroDto
    {
        public int Id { get; set; } 
        public string Nome { get; set; }

        public TipoBairro tipoBairro { get; set; }
    }
}

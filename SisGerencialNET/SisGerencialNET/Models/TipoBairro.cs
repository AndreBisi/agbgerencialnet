namespace SisGerencialNET.Models
{
    public class TipoBairro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Abreviacao { get; set; }

        public ICollection<Bairro> Bairros { get; set; }

        public override string ToString()
        {
            return $"({Id}) - {Nome}";
        }
    }
}

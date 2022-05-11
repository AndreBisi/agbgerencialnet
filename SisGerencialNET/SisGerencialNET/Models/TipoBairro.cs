namespace SisGerencialNET.Models
{
    public class TipoBairro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Abreviacao { get; set; }

        public IList<Bairro> Bairros { get; set; }

        public TipoBairro()
        {
            Bairros = new List<Bairro>();   
        }

        public override string ToString()
        {
            return $"({Id}) - {Nome}";
        }
    }
}

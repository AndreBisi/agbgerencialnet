namespace SisGerencialNET.Models
{
    public class TipoBairro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Abreviacao { get; set; }

        public IList<Bairro> BairroList { get; set; }

        public TipoBairro()
        {
            BairroList = new List<Bairro>();    
        }

    }
}

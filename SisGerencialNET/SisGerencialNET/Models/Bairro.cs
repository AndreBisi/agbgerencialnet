namespace SisGerencialNET.Models
{
    public class Bairro
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public int? TipoBairroID { get; set; }
        public TipoBairro TipoBairro { get; set; }

        public Bairro()
        {
            TipoBairro = new TipoBairro();
        }
    }
}

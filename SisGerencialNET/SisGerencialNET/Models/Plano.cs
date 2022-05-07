using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisGerencialNET.Models
{
    public class Plano
    {

        public int Id { get; set; }

        public string? Nome { get; set; }

        public bool Ativo { get; set; }

    }
}

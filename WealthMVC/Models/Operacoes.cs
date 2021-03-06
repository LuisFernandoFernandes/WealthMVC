using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WealthMVC.Enums;

namespace WealthMVC.Models
{
    [Table("OPERACOES")]
    public class Operacoes : GenericModel
    {
        [Column("Tipo")]
        [Display(Name = "Tipo")]
        public eOperacoesTipo Tipo { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Column("AtivosId")]
        [Display(Name = "Ativos")]
        public string? AtivosId { get; set; }
        [ForeignKey("AtivosId")]
        public Ativos? Ativos { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade")]
        public string Quantidade { get; set; }

        [Column("Preco")]
        [Display(Name = "Preço")]
        public string Preco { get; set; }
    }
}

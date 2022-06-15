using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WealthMVC.Models
{
    public class Portifolio : GenericModel
    {
        [Column("AtivosId")]
        [Display(Name = "Ativos")]
        public string? AtivosId { get; set; }
        [ForeignKey("AtivosId")]
        public Ativos? Ativos { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade")]
        public double? Quantidade { get; set; }

        [Column("Preco")]
        [Display(Name = "Preço")]
        public double? Preco { get; set; }

        [Column("PrecoAtual")]
        [Display(Name = "Preço Atual")]
        public double? PrecoAtual { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WealthMVC.Models
{
    [Table("PORTIFOLIO")]
    public class Portifolio : GenericModel
    {
        [Column("AtivosId")]
        [Display(Name = "Ativos")]
        public string? AtivosId { get; set; }
        [ForeignKey("AtivosId")]
        public Ativos? Ativos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WealthMVC.Models
{
    public class Portifolio : GenericModel
    {
        [Display(Name = "Ativos")]
        public string? AtivosId { get; set; }
        [ForeignKey("AtivosId")]
        public Ativos? Ativos { get; set; }

        [Display(Name = "Operações")]
        public string? OperacoesId { get; set; }
        [ForeignKey("OperacoesId")]
        public Operacoes? Operacoes { get; set; }
    }
}

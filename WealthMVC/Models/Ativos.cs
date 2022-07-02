using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WealthMVC.Enums;

namespace WealthMVC.Models
{
    [Table("ATIVOS")]
    public class Ativos : GenericModel
    {
        [Column("Classe")]
        [Display(Name = "Classe")]
        public eAtivosClasse Classe { get; set; }

        [Column("Codigo")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }

}

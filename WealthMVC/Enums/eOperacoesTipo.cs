using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WealthMVC.Enums
{
    public enum eOperacoesTipo
    {
        [Display(Name = "Compra")]
        Compra = 0,

        [Display(Name = "Venda")]
        Venda = 1,

        //[Display(Name = "Dividendo")]
        //Dividendo,

        //[Display(Name = "Juros Sobre Capital Próprio")]
        //JurosSobreCapitalProprio,

        //[Display(Name = "Rendimento")]
        //Rendimento,

        //[Display(Name = "Bonificação")]
        //Bonificacao,

        //[Display(Name = "Desdobramento")]
        //Desdobramento,

        //[Display(Name = "Grupamento")]
        //Grupamento,
    }
}

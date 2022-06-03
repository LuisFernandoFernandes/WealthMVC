using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WealthMVC.Enums
{
    public enum eOperacoesTipo
    {
        [EnumMember(Value = "Compra")]
        [Display(Name = "Compra")]
        Compra,

        [EnumMember(Value = "Venda")]
        [Display(Name = "Venda")]
        Venda,

        [EnumMember(Value = "Dividendo")]
        [Display(Name = "Dividendo")]
        Dividendo,

        [EnumMember(Value = "Juros Sobre Capital Próprio")]
        [Display(Name = "Juros Sobre Capital Próprio")]
        JurosSobreCapitalProprio,

        [EnumMember(Value = "Rendimento")]
        [Display(Name = "Rendimento")]
        Rendimento,

        [EnumMember(Value = "Bonificação")]
        [Display(Name = "Bonificação")]
        Bonificacao,

        [EnumMember(Value = "Desdobramento")]
        [Display(Name = "Desdobramento")]
        Desdobramento,

        [EnumMember(Value = "Grupamento")]
        [Display(Name = "Grupamento")]
        Grupamento,
    }
}

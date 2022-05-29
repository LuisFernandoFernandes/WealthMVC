using System.Runtime.Serialization;

namespace WealthMVC.Enums
{
    public enum eOperacoesTipo
    {
        [EnumMember(Value = "Compra")]
        Compra,

        [EnumMember(Value = "Venda")]
        Venda,

        [EnumMember(Value = "Dividendo")]
        Dividendo,

        [EnumMember(Value = "Juros Sobre Capital Próprio")]
        JurosSobreCapitalProprio,

        [EnumMember(Value = "Rendimento")]
        Rendimento,

        [EnumMember(Value = "Bonificação")]
        Bonificacao,

        [EnumMember(Value = "Desdobramento")]
        Desdobramento,

        [EnumMember(Value = "Grupamento")]
        Grupamento,
    }
}

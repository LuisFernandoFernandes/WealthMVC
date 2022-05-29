using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace WealthMVC.Enums
{
    public enum eAtivosClasse
    {
        #region Renda Variável Nacional

        [Display(Name = "Ação")]
        Acao,

        [EnumMember(Value = "ETF")]
        EtfBrasil,

        [EnumMember(Value = "FII")]
        Fii,

        [EnumMember(Value = "BDR")]
        Bdr,

        #endregion

        #region Renda Variável Exterior

        [EnumMember(Value = "Stock")]
        Stock,

        [EnumMember(Value = "ETF")]
        EtfExterior,

        [EnumMember(Value = "Reits")]
        Reits,

        [EnumMember(Value = "ADR")]
        ADR,
        #endregion

    }
}

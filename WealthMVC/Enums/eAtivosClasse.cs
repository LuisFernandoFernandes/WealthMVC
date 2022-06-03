using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WealthMVC.Enums
{
    public enum eAtivosClasse
    {
        #region Renda Variável Nacional


        //[EnumMember(Value = "Ação")]
        [Display(Name = "Ação")]
        Acao,

        //[EnumMember(Value = "Compra")]
        [Display(Name = "ETF")]
        EtfBrasil,

        //[EnumMember(Value = "FII")]
        [Display(Name = "FII")]
        Fii,

        //[EnumMember(Value = "BDR")]
        [Display(Name = "BDR")]
        Bdr,

        #endregion

        #region Renda Variável Exterior

        [EnumMember(Value = "Stock")]
        [Display(Name = "Stock")]
        Stock,

        [EnumMember(Value = "ETF")]
        [Display(Name = "ETF")]
        EtfExterior,

        [EnumMember(Value = "Reits")]
        [Display(Name = "Reits")]
        Reits,

        [EnumMember(Value = "ADR")]
        [Display(Name = "ADR")]
        ADR,
        #endregion

    }
}

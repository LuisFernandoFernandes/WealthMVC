using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WealthMVC.Enums
{
    public enum eAtivosClasse
    {
        #region Renda Variável Nacional


        [Display(Name = "Ação")]
        Acao,

        [Display(Name = "ETF")]
        EtfBrasil,

        [Display(Name = "FII")]
        Fii,

        [Display(Name = "BDR")]
        Bdr,

        #endregion

        #region Renda Variável Exterior

        [Display(Name = "Stock")]
        Stock,

        [Display(Name = "ETF")]
        EtfExterior,

        [Display(Name = "Reits")]
        Reits,

        [Display(Name = "ADR")]
        ADR,
        #endregion

    }
}

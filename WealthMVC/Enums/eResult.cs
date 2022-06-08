using System.ComponentModel.DataAnnotations;

namespace WealthMVC.Enums
{
    public enum eResult
    {
        [Display(Name = "OK")]
        Ok,

        [Display(Name = "Invalid")]
        Invalid,

        [Display(Name = "Not Found")]
        NotFound,
    }
}

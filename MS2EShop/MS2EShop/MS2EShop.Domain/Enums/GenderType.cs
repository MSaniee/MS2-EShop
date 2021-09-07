using System.ComponentModel.DataAnnotations;

namespace MS2EShop.Domain.Enums
{
    public enum GenderType
    {
        [Display(Name = "مرد")]
        Male = 1,

        [Display(Name = "زن")]
        FeMale = 2,
    }
}

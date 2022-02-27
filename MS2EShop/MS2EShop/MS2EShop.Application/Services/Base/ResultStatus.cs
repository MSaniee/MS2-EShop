using System.ComponentModel.DataAnnotations;

namespace MS2EShop.Application.Services.Base;

public enum ResultStatus
{
    [Display(Name = "Success")]
    Success = 0,

    [Display(Name = "BadRequest")]
    BadRequest = 2,

    [Display(Name = "NotFound")]
    NotFound = 3,

    [Display(Name = "ListEmpty")]
    ListEmpty = 4,

    [Display(Name = "LogicError")]
    LogicError = 5,
}

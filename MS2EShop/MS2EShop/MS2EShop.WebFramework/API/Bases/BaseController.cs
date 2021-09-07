using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS2EShop.WebFramework.API.Filters;

namespace MS2EShop.WebFramework.API.Bases
{
    [ApiController]
    [Authorize]
    [ApiResultFilter]
    //[ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[area]/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
    }
}

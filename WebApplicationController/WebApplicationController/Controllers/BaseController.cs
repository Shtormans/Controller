using Microsoft.AspNetCore.Mvc;
using WebApplicationController.Model;

namespace WebPhoneController.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult CreateOKResponse<T>(T value)
        {
            var result = new BaseResponse<T>(value);
            result.Success = true;

            return Ok(result);
        }

        protected IActionResult CreateErrorResponse<T>(string error)
        {
            var result = new BaseResponse<T>();
            result.Success = false;
            result.Error = error;

            return NotFound(result);
        }
    }
}

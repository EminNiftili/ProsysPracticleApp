using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProsysTestApp.ApiConfig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProsysTestApp.ApiConfig.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AsBadResult(
                         string message)
                         => AsActionResult<object>(HttpStatusCode.BadRequest, message, null);

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AsSuccessResult(
                         string message)
                         => AsActionResult<object>(HttpStatusCode.OK, message, null);

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AsSuccessResult<T>(
            string message,
            T? data)
            => AsActionResult(HttpStatusCode.OK, message, data);

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AsSuccessResult<T>(
            T? data)
            => AsActionResult(HttpStatusCode.OK, string.Empty, data);


        [ApiExplorerSettings(IgnoreApi = true)]
        private IActionResult AsActionResult<T>(
            HttpStatusCode statusCode,
            string message,
            T? data)
        {
            var statusCodeAsInt = (int)statusCode;
            var responseModel = new ApiResponse<T>
            {
                Data = data,
                Message = message,
                StatusCode = statusCodeAsInt
            };

            return this.StatusCode(statusCodeAsInt, responseModel);
        }
    }
}

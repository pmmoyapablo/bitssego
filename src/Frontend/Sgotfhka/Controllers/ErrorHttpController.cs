using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sisgtfhka.Models;

namespace Sisgtfhka.Controllers
{
    public class ErrorHttpController : Controller
    {
        [Route("ErrorHttp/Handle/{errorCode}")]
        public IActionResult Handle(int errorCode)
        {
            // Do something and return a view or a content
            ViewBag.Message = errorCode;

            return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
        }
    }
}
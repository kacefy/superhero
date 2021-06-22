using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using System.Net.Http;
namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var mergedService = "https://localhost:44305/merge";
            var thirdServiceResponseCall = await new HttpClient().GetStringAsync(mergedService);
            ViewBag.responseCall = thirdServiceResponseCall;
            return View();

        }
    }
}

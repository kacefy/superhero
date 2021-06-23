using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
  
            var mergedService = $"{Configuration["mergedServiceURL"]}/superheromerge";
            var thirdServiceResponseCall = await new HttpClient().GetStringAsync(mergedService);
            ViewBag.responseCall = thirdServiceResponseCall;
            return View();

        }
    }
}

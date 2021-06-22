using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SecondNames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecondNamesController : ControllerBase
    {

        public static readonly string[] SecondName = new[] {
            "Gambit", "Man", "Woman", "Torpedo", "Flash", "Mastermind", "Girl", "Boy", "Freeze", "Hurricane", "Blaze", "Steel", "Sandstorm", "Mage"
       };


        [HttpGet]

        public ActionResult<string> Get()
        {
            var rnd = new Random();
            var returnindex = rnd.Next(0, 25);
            return SecondName[returnindex].ToString();

        }
    }
}


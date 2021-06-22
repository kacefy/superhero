using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstNames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstNamesController : ControllerBase
    {
        public static readonly string[] FirstName = new[] {
            "Mister", "Miss", "Mighty", "The", "Super", "Incredible", "Thunder", "Lightning", "Ice", "Great", "Victorious", "Valiant", "Hyper", "Amazing"
       };


        [HttpGet]

        public ActionResult<string> Get()
        {
            var rnd = new Random();
            var returnindex = rnd.Next(0, 25);
            return FirstName[returnindex].ToString();

        }
    }
}

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
        public static readonly string[] HeroFirstName = new[] {
            "Mister", "Wonder", "Mighty", "The", "Super", "Incredible", "Thunder", "Lightning", "Ice", "Great", "Victorious", "Valiant", "Hyper", "Invincible"
       };

        public static readonly string[] VillainFirstName = new[] {
            "Mister", "Miss", "Notorious", "The", "Evil", "Mischievious", "Killer", "Dark", "Ice", "Mysterious", "Death", "Storm", "Red", "Destructive"
       };


        [HttpGet]

        public ActionResult<string> Get()
        {
            var rnd = new Random();
            var returnindex = rnd.Next(0, 13);

            var result = $"{HeroFirstName[returnindex].ToString() + " " + VillainFirstName[returnindex].ToString()}";
            return result;

        }
    }
}

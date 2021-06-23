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

        public static readonly string[] HeroSecondName = new[] {
            "Phoenix", "Man", "Woman", "Torpedo", "Flash", "Mastermind", "Girl", "Boy", "Freeze", "Hurricane", "Blaze", "Steel", "Sandstorm", "Mage"
       };

        public static readonly string[] VillainSecondName = new[] {
            "Gambit", "Man", "Woman", "Wizard", "Mage", "Nightmare", "Queen", "King", "Freeze", "Hurricane", "Widow", "Criminal", "Serpent", "Witch"
       };

        [HttpGet]

        public ActionResult<string> Get()
        {
            var rnd = new Random();
            var returnindex = rnd.Next(0, 13);

            var result = $"{HeroSecondName[returnindex].ToString() + " " + VillainSecondName[returnindex].ToString()}";
            return result;
        }



    }
}


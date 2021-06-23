using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace Merge.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class SuperheroMergeController : ControllerBase

    {

        private IConfiguration Configuration;

        public SuperheroMergeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var FirstNamesService = $"{Configuration["firstnamesServiceURL"]}/firstnames";
            var firstnamesResponseCall = await new HttpClient().GetStringAsync(FirstNamesService);


            var SecondNamesService = $"{Configuration["secondnamesServiceURL"]}/secondnames";
            var secondnamesResponseCall = await new HttpClient().GetStringAsync(SecondNamesService);

            var herofirstandlastname = firstnamesResponseCall.Split(" ")[0] + " " + secondnamesResponseCall.Split(" ")[0];
            var villanfirstandlastname = firstnamesResponseCall.Split(" ")[1] + " " + secondnamesResponseCall.Split(" ")[1];

            var mergedResponse = $"{herofirstandlastname}{","}{villanfirstandlastname}";
            return Ok(mergedResponse);

        }
    }
}

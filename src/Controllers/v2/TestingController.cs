using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyNetCoreWebAPI.Controllers.v2
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiVersion("2.1")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly ILogger<TestingController> logger;

        [HttpGet]
        [Route("stringListGet")]
        [MapToApiVersion("2.0")]
        public IEnumerable<string> GetstringList(int id)
        {
            List<string> result = new List<string>() { "AAA" + id, "BBB" + id, "CCC" + id };

            return result;
        }

        [HttpGet]
        [Route("stringListGetv2")]
        [MapToApiVersion("2.1")]
        public IEnumerable<string> GetstringListv2(int id)
        {
            List<string> list1 = new List<string>();
            MySample obj1 = new MySample() { name = "Pankaj", Age = 35 };
            MySample obj2;
            obj2 = obj1;

            MySample obj3 = new MySample() { name = "Pankaj", Age = 35 };
            return result;
        }

        [HttpGet]
        [Route("stringListGetv2")]
        [MapToApiVersion("2.1")]
        public string Get()
        {
            string result = string.Empty;

            return result;
        }
    }
}

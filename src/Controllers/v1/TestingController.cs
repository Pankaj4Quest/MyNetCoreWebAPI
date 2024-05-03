using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace MyNetCoreWebAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly ILogger<TestingController> logger;

        [HttpGet]
        [Route("stringListGet")]
        [MapToApiVersion("1.0")]
        public IEnumerable<string> GetstringList(int id)
        {
            List<string> result = new List<string>() { "abc" + id, "def" + id, "ghi" + id };

            return result;
        }

        [HttpGet]
        [Route("stringListGetv2")]
        [MapToApiVersion("1.1")]
        public IEnumerable<MySample> GetstringListv2(int id)
        {
            List<MySample> list1 = new List<MySample>()
            {
                new MySample{Age=35,name="Pankaj"},
                new MySample{Age=36,name="Ajay"},
                new MySample{Age=35,name="Rahul"},
            };

            List<MySample> list2 = new List<MySample>()
            {
                new MySample{Age=35,name="Eva"},
                new MySample{Age=36,name="Ajay"},
                new MySample{Age=35,name="Sumit"},
            };


            var list3 = list1.Intersect(list2, new listEquality());
            var list4 = list1.Where(o => list2.Any(p => o.Age == p.Age && o.name == p.name));
            List<MySample> finalList = new List<MySample>();
            foreach (var item in list4)
            {
                finalList.Add(item);
            }

            return finalList;
        }

        [HttpGet]
        [Route("stringGet")]
        [MapToApiVersion("1.0")]
        public string Get()
        {
            string input = "Hello world!";
            var result = new string(input.Distinct().ToArray());

            return result;
        }
    }
    public class MySample
    {
        public string name;
        public int Age;
    }

    public class listEquality : IEqualityComparer<MySample>
    {
        public bool Equals(MySample? x, MySample? y)
        {
            return x.name==y.name && x.Age==y.Age; ;
        }

        public int GetHashCode([DisallowNull] MySample obj)
        {
            return obj.name.GetHashCode() ^ obj.Age.GetHashCode();
        }
    }
}

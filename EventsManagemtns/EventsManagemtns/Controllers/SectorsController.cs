using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly DbContextImpl context;
        public SectorsController(DbContextImpl contextImpl)
        {
            context = contextImpl;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var enumerable = context.Sectors.ToList().Select(x => new
            {
                id = x.Id,
                value = x.Name
            });

            return enumerable;
        }

        [HttpPost]
        public void Post([FromBody] Sector sector)
        {
            context.Sectors.Add(sector);
            context.SaveChanges();

        }
    }
}

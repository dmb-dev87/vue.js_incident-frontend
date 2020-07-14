using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly DbContextImpl context;
        public IncidentsController(DbContextImpl contextImpl)
        {
            context = contextImpl;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var enumerable = context.Incidents.ToList().Select(x => new
            {
                id = x.Id,
                Subject = x.Subject,
                sver = new  { code = 1, label = "المستوى الخامس" },
                Org = new { code = 1, label = "المستوى الخامس" },
                Status = new { code = 1, label = "المستوى الخامس" },
                Cat = new { code = 1, label = "المستوى الخامس" },
                Description = x.Description,
                Sector = new { code = 1, label = "المستوى الخامس" },
                Urgancey  = new { code = 1, label = "المستوى الخامس" }
            });

            return enumerable;
        }

        [HttpPost]
        public void Post([FromBody] Incident incident)
        {
            context.Incidents.Add(incident);
            context.SaveChanges();
        }
    }
}

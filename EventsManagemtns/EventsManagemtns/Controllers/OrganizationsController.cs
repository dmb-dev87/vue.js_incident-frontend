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
    public class OrganizationsController : ControllerBase
    {
        private readonly DbContextImpl context;
        public OrganizationsController(DbContextImpl contextImpl)
        {
            context = contextImpl;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var enumerable = context.Organizations.ToList().Select(x => new
            {
                id = x.Id,
                name = x.Name,
                sectorID = x.SectorID
            });

            return enumerable;
        }

        [HttpGet]
        [Route("{sectorId:int}/BySector")]
        public IEnumerable<object> GetBySectorId(int sectorId)
        {
            var enumerable = context.Organizations.Where(o=>o.SectorID == sectorId).ToList().Select(x => new
            {
                id = x.Id,
                name = x.Name,
                sectorID = x.SectorID
            });

            return enumerable;
        }

        [HttpPost]
        public void Post([FromBody] Organization organization)
        {
            context.Organizations.Add(organization);
            context.SaveChanges();

        }
    }
}

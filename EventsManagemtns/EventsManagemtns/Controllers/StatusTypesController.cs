using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTypesController : ControllerBase
    {

        private readonly DbContextImpl context;

        public StatusTypesController(DbContextImpl impl) {
            context = impl;        
        }

        // GET: api/<StatusTypesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StatusTypesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatusTypesController>
        [HttpPost]
        public void Post([FromBody] List<StatusType> comingList)
        {
            // get all from db
            List<StatusType> dbList = context.statusTypes.ToList();
            // found the delted ones
            List<StatusType> newStatus = comingList.Where(c => !dbList.Any(x => x.id == c.id)).ToList();
            List<StatusType> deleteStatus = dbList.Where(c => !comingList.Any(x => x.id == c.id)).ToList();
            context.statusTypes.AddRange(newStatus);

            // 1 - he collect the data from the database;
            // 2- he created a list of deleted statuess
            // 3- he created a list of new status
            // 4- he created a list of updated status

            // 5 - he removed the deleted list ..
            // 6 - he updated the updated list.. 
            // 7 - he added the new list .. 
            // https://www.thereformedprogrammer.net/updating-a-many-to-many-relationship-in-entity-framework

            context.SaveChanges();
        }

        // PUT api/<StatusTypesController>/5
        [HttpPut]
        public void Put([FromBody] StatusType value)
        {

            StatusType statusType = context.statusTypes.Where(x => x.id == value.id).SingleOrDefault();
            statusType.statuses = value.statuses;
            context.statusTypes.Add(statusType);
            context.SaveChanges();


        }

        // DELETE api/<StatusTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}

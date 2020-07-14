using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AptsController : ControllerBase
    {

        private readonly DbContextImpl context;
        public AptsController(DbContextImpl impl) {
            context = impl;
        }
        // GET: api/<AptsController>
        [HttpGet]
        public List<APT> Get()
        {
            var queryables = context.Apts.Select(a => new
            {
                id = a.id,
                AlternativeNames = a.AlternativeNames.ToList(),
                ThreatSignatures = a.ThreatSignatures.ToList(),
                Name = a.Name,
                Contents = a.Contents.ToList(),
                OriginCountries = a.OriginCountries.ToList(),
                TargetedCountries = a.TargetedCountries.ToList()

            }) ;

            var lists = queryables.AsEnumerable().Select(x => new APT {
                AlternativeNames =  x.AlternativeNames,
                id = x.id,
                Name = x.Name,
                Contents = x.Contents,
                OriginCountries = x.OriginCountries,
                ThreatSignatures = x.ThreatSignatures,
                TargetedCountries = x.TargetedCountries
            }).ToList();

            return lists;
        }

        // GET api/<AptsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AptsController>
        [HttpPost]
        public void Post([FromBody] APT apt)
        {
            List<Country> targetedCountries = new List<Country>();
            List<Country> originCountry = new List<Country>();


            foreach (Country c in apt.TargetedCountries)
            {
                targetedCountries.Add(context.Countries.Find(c.Id));
            }
            foreach (Country c in apt.OriginCountries)
            {
                originCountry.Add(context.Countries.Find(c.Id));
            }
            apt.OriginCountries = originCountry;
            apt.TargetedCountries = targetedCountries;

            context.Apts.Add(apt);
            context.SaveChanges();
        }

        // PUT api/<AptsController>/5
        [HttpPut]
        public void Put([FromBody] APT newAPT)
        {
            var queryables = context.Apts.Where(x => x.id == newAPT.id).Select(a => new
            {
                id = a.id,
                AlternativeNames = a.AlternativeNames.ToList(),
                ThreatSignatures = a.ThreatSignatures.ToList(),
                Name = a.Name,
                Contents = a.Contents.ToList(),
                OriginCountries = a.OriginCountries.ToList(),
                TargetedCountries = a.TargetedCountries.ToList()

            });

            var lists = queryables.AsEnumerable().Select(x => new APT
            {
                AlternativeNames = x.AlternativeNames,
                id = x.id,
                Name = x.Name,
                Contents = x.Contents,
                OriginCountries = x.OriginCountries,
                ThreatSignatures = x.ThreatSignatures,
                TargetedCountries = x.TargetedCountries
            }).ToList();



            APT aPT = lists.ElementAt(0);

            List<Country> targetedCountries = new List<Country>();
            List<Country> originCountry = new List<Country>();


            foreach (Country c in newAPT.TargetedCountries)
            {
                targetedCountries.Add(context.Countries.Find(c.Id));
            }

            foreach (Country c in newAPT.OriginCountries)
            {
                originCountry.Add(context.Countries.Find(c.Id));
            }

            context.Entry(aPT).CurrentValues.SetValues(newAPT);
            context.SaveChanges();
        }

        // DELETE api/<AptsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

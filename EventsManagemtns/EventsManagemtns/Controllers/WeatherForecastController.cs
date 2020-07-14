using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsManagemtns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DbContextImpl _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DbContextImpl context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet]
        public List<string> Get()
        {
            APT apt = new APT();
            Country country = new Country();
            country.Id = 1026;
            country.CountryName = "أندورا";
            country.Contenant = "EU";
            ThreatSignature signature = new ThreatSignature();
            AlternativeName name = new AlternativeName();
            name.Serial = 1;
            name.Name = "alternativeName";
            signature.DomainName = "domain";
            signature.Serial = 2;
            signature.Name = "signature Name";
            apt.TargetedCountries = new List<Country> { country };
            apt.OriginCountries = new List<Country> { country };
            apt.ThreatSignatures = new List<ThreatSignature> { signature };
            apt.AlternativeNames = new List<AlternativeName> { name };
            
            apt.Name = "سالم";
            List<Country> targetedCountries = new List<Country>();
            List<Country> originCountry = new List<Country>();


            foreach (Country c in apt.OriginCountries)
            {
                targetedCountries.Add(_context.Countries.Find(c.Id));
            }

            foreach (Country c in apt.OriginCountries)
            {
                originCountry.Add(_context.Countries.Find(c.Id));
            }
            apt.OriginCountries = originCountry;
            apt.TargetedCountries = targetedCountries;

            _context.Apts.Add(apt);
            _context.SaveChanges();

            return new List<String> { "Salim" };
        }
    }
}

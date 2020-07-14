using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsManagemtns
{
    public class Organization
    {
        public int Id { set; get; }
        public string Name { get; set; }

        [ForeignKey("Sector")]
        public int SectorID { get; set; }
        public Sector Sector { get; set; }
    }
}

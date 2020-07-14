using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static EventsManagemtns.Enums.Enums;

namespace EventsManagemtns
{
    public class Incident
    {
        public int Id { set; get; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Urgancey Urgancey { get; set; }
        public IncidentStatus Status { get; set; }
        public Category Category { get; set; }
        public Sverity Sverity { get; set; }
        public string SourceIpAddress {get; set;}
        public string DestinationIpAddress {get; set;}

        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsManagemtns
{
    public class APT
    {

        public int id { set; get; }
        public String Name { set; get; }
        public IList<Country> TargetedCountries { set; get; }
        public IList<Country> OriginCountries { set; get; }
        public IList<Content> Contents { set; get; }
        public IList<ThreatSignature> ThreatSignatures { set; get; }
        public IList<AlternativeName> AlternativeNames { set; get; }
        public IList<AttachmentProp> Attachments { set; get; }
        public int Counter { get; set; }
        public bool DbSuccess { get; set; }

    }
}

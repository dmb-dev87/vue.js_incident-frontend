using EventsManagemtns.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EventsManagemtns
{
    [DbConfigurationType(typeof(CodeConfig))]
    public class DbContextImpl : DbContext
    {

        public DbContextImpl(string constring) : base(constring)
        {
        }

        public DbSet<AttachmentProp> AttachmentProps { get; set; }
        public DbSet<APT> Apts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<StatusType> statusTypes { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Incident> Incidents { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Country>()
                .HasMany(c => c.targeted)
                .WithMany(a => a.TargetedCountries)
                .Map(sd => sd.ToTable("TargetedCountries"));

            modelBuilder.Entity<APT>()
                .HasMany(a=> a.Attachments)
                .WithMany(att => att.apts)
                .Map(sd => sd.ToTable("AptAttachments"));


            modelBuilder.Entity<Country>()
                .HasMany(c => c.origin)
                .WithMany(a => a.OriginCountries)
                .Map(sd => sd.ToTable("OriginCountries"));

            base.OnModelCreating(modelBuilder);
        }
    }

    public class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            SetProviderServices("System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }

    }
    }

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace EventsManagemtns
{
    public class ContextFactory : IDbContextFactory<DbContextImpl>
    {

        DbContextImpl IDbContextFactory<DbContextImpl>.Create()
        {
            return new DbContextImpl("Server=DEVELOPMENT\\MSSQLENT2014;Database=cdcdb;User Id=sa; Password=x6-4C37M;");
        }
    }
}

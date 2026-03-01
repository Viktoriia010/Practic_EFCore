using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Context;

using global::Academy.Configurator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


public class AcademyDbContextFactory
     : IDesignTimeDbContextFactory<AcademyDbContext>
    {
        public AcademyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AcademyDbContext>();

            DbContextConfigurator.Configure(optionsBuilder);

            return new AcademyDbContext(optionsBuilder.Options);
        }
    }


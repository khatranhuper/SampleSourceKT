using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Data.EF
{
    public class SampleSourceKTFactory : IDesignTimeDbContextFactory<SampleSourceKTDbContext>
    {
        public SampleSourceKTDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleSourceKTDbContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SampleSourceKTDatabase"));

            return new SampleSourceKTDbContext(optionsBuilder.Options);
        }
    }
}

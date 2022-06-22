
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SampleSourceKT.Data.EF;
using SampleSourceKT.Data.Entities;
using SampleSourceKT.Data.Infrastructure.IRepositories;
using SampleSourceKT.Data.Infrastructure.Repositories;
using SampleSourceKT.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSourceKT.Data
{
    public static class SampleSourceKTDataBoootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            string conn = Configuration["ConnectionStrings:SampleSourceKTDatabase"];
            services.AddDbContext<SampleSourceKTDbContext>(options => options.UseSqlServer(conn), ServiceLifetime.Transient);
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SampleSourceKTDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IProductRespository, ProductRespository>();
            //options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));
        }
    }
}

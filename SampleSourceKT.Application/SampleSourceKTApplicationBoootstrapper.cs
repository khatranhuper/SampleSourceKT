using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleSourceKT.Application.ApplicationServices;
using SampleSourceKT.Application.Mapping;
using SampleSourceKT.Application.ServiceContracts.Products;
using SampleSourceKT.Application.ServiceContracts.Users;
using SampleSourceKT.Data;
using SampleSourceKT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Application
{
    public static class SampleSourceKTApplicationBoootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            //Mapper
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddTransient<IProductServices, ProductSerivces>();
            services.AddTransient<IUserServices, UserSerivices>();
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();


            SampleSourceKTDataBoootstrapper.RegisterServices(services, Configuration);
        }
    }
}

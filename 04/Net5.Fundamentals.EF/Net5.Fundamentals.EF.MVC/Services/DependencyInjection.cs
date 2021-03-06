using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net5.Fundamentals.EF.CodeFirst.Data.Contexts;
using Net5.Fundamentals.EF.CodeFirst.Data.Entities;
using Net5.Fundamentals.EF.CodeFirst.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.EF.MVC.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {   
            services.AddScoped<IBlogService, BlogService>();
            
            return services;
        }
    }
}

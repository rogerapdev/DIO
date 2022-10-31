using Mercadinho.Infrastructure.Data.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Infrastructure.Data.Registration
{
    public static class DataRegsitration
    {
        public static IServiceCollection AddDataRegistration(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DbContext, Context>(options =>
            {
                var connectionString = configuration.GetConnectionString("sql_connection");
                var serverVersion = MariaDbServerVersion.AutoDetect(connectionString);

                options.UseMySql(connectionString, serverVersion);
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}

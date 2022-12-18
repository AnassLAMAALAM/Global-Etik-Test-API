using Global.Etik.Application.Common.Contracts.Presentences;
using Global.Etik.Presentence.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Presentence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<GlobalEtikDbContext>(options =>
                options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            return services;
        }
    }
}

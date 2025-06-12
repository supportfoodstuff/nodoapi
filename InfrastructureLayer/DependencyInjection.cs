// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using InfrastructureLayer.Data;
// using System;

// namespace InfrastructureLayer
// {
//     public static class DependencyInjection
//     {
//         public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
//         {
//             var connectionString = configuration.GetConnectionString("DefaultConnection");

//             services.AddDbContext<AppDbContext>(options =>
//             {
//                 options.UseMySql(
//                     connectionString,
//                     ServerVersion.AutoDetect(connectionString)
//                 );
//             });

//             return services;
//         }
//     }
// }


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InfrastructureLayer.Data;
using System;

namespace InfrastructureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = GetConnectionString(configuration);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                );
            });

            return services;
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            // Railway provides MYSQL_URL environment variable
            var mysqlUrl = Environment.GetEnvironmentVariable("MYSQL_URL");
            
            if (!string.IsNullOrEmpty(mysqlUrl))
            {
                // Parse Railway's MYSQL_URL: mysql://user:password@host:port/database
                var uri = new Uri(mysqlUrl);
                var host = uri.Host;
                var port = uri.Port;
                var database = uri.AbsolutePath.TrimStart('/');
                var userInfo = uri.UserInfo.Split(':');
                var username = userInfo[0];
                var password = userInfo.Length > 1 ? userInfo[1] : "";
                
                return $"Server={host};Port={port};Database={database};Uid={username};Pwd={password};";
            }
            
            // Fallback to local development connection string
            return configuration.GetConnectionString("DefaultConnection") ?? "";
        }
    }
}

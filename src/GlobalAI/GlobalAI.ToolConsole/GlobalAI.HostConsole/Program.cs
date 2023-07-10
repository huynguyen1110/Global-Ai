using GlobalAI.DataAccess.Base;
using GlobalAI.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oracle.EntityFrameworkCore.Diagnostics;

namespace GlobalAI.HostConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((hostContext, services) =>
                {
                    //nếu có cấu hình redis
                    string connectionString = hostContext.Configuration.GetConnectionString("GLOBALAI");
                    services.AddSingleton(new DatabaseOptions { ConnectionString = connectionString });

                    //entity framework
                    services.AddDbContext < GlobalAIDbContext>(options =>
                    {
                        options.UseOracle(connectionString, option => option.MigrationsAssembly("GlobalAI.HostConsole"));
                        options.ConfigureWarnings(b => b.Ignore(OracleEventId.DecimalTypeDefaultWarning));
                    }, ServiceLifetime.Transient);
                });
    }
}
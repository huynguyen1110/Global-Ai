using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Swashbuckle.AspNetCore.SwaggerUI;

#region config ocelot
var aspEnv = $"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}";
var ocelotEnv = $"{Environment.GetEnvironmentVariable("OCELOT_ENVIRONMENT")}";
if (string.IsNullOrEmpty(ocelotEnv))
{
    ocelotEnv = aspEnv;
}

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile($"ocelot{(ocelotEnv != null ? "." + ocelotEnv : "")}.json", false, true)
                            .Build();
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddOcelot(configuration);
#endregion

#region services
string CmsAllowOrigins = "_cmsAllowOrigins";
var Configuration = builder.Configuration;

services.AddHealthChecks();
services.Configure<FormOptions>(x =>
{
    x.MultipartBodyLengthLimit = Int32.MaxValue;
});
services.AddControllers();

services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.All;
});

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GlobalAI.APIGateway", Version = "v1" });
});

services.AddSwaggerForOcelot(configuration);


string allowOrigins = Configuration.GetSection("AllowedHosts").Value;
var origins = allowOrigins.Split(';');

services.AddCors(options =>
{
    options.AddPolicy(name: CmsAllowOrigins,
        builder =>
        {
            builder
                .WithOrigins(origins)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Content-Disposition");
        });
});
#endregion

#region app
var app = builder.Build();
if (!builder.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerForOcelotUI(opt =>
    {
        //opt.SwaggerEndpoint("");
        //opt.PathToSwaggerGenerator = "/swagger/docs";
        //opt.DocExpansion(DocExpansion.None);
    });
}

app.UseForwardedHeaders();
//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});

app.UseCors(CmsAllowOrigins); // allow credentials

app.UseWebSockets();
app.UseOcelot().Wait();

//loggerFactory.AddLog4Net();

app.Run();
#endregion
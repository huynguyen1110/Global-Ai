using GlobalAI.CoreDomain.Implements;
using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.DataAccess.Base;
using GlobalAI.Entites;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PemUtils;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
    .AddEnvironmentVariables();
// Add services to the container.

builder.Services.AddControllers();

var Configuration = builder.Configuration;

var services = builder.Services;

// Register the signing and encryption credentials.
RsaSecurityKey key;

var path = Configuration.GetValue<string>("JwtKey");
var accessTokenLifeTime = Configuration.GetValue<int>("Authorize:AccessTokenLifetime");
var refreshTokenLifeTime = Configuration.GetValue<int>("Authorize:RefreshTokenLifetime");

using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
using (var reader = new PemReader(stream))
{
    key = new RsaSecurityKey(reader.ReadRsaKey());
}

#region database
string connectionString = Configuration.GetConnectionString("GLOBALAI");
services.AddDbContext<GlobalAIDbContext>(options =>
{
    // Configure Entity Framework Core to use Microsoft SQL Server.
    options.UseOracle(connectionString);

    // Register the entity sets needed by OpenIddict.
    // Note: use the generic overload if you need to replace the default OpenIddict entities.
    options.UseOpenIddict();
});
services.AddSingleton(new DatabaseOptions { ConnectionString = connectionString });
#endregion

#region config authorize server 
services
    .AddOpenIddict()

        // Register the OpenIddict core components.
        .AddCore(options =>
        {
            // Configure OpenIddict to use the Entity Framework Core stores and models.
            // Note: call ReplaceDefaultEntities() to replace the default entities.
            options.UseEntityFrameworkCore()
                   .UseDbContext<GlobalAIDbContext>();
        })

        // Register the OpenIddict server components.
        .AddServer(options =>
        {
            // Enable the token endpoint.
            options.SetTokenEndpointUris("connect/token");

            // Enable the client credentials flow.
            options.AllowPasswordFlow()
                    .AllowRefreshTokenFlow()
                    .SetAccessTokenLifetime(TimeSpan.FromMinutes(accessTokenLifeTime))
                    .SetRefreshTokenLifetime(TimeSpan.FromDays(refreshTokenLifeTime));
            ;

            // Accept anonymous clients (i.e clients that don't send a client_id).
            options.AcceptAnonymousClients();

            // Disable mã hóa token (Vd: dùng dòng này thì jwt.io đọc được, cmt vào thì ko đọc đc)
            options.DisableAccessTokenEncryption();

            // Add key mã hóa vs signing
            options.AddEncryptionKey(key)
                    .AddSigningKey(key)
            ;

            // Register the ASP.NET Core host and configure the ASP.NET Core options.
            options.UseAspNetCore()
                   .EnableTokenEndpointPassthrough()
                   .DisableTransportSecurityRequirement()
                   ;
        })

        // Register the OpenIddict validation components.
        .AddValidation(options =>
        {
            // Import the configuration from the local OpenIddict server instance.
            options.UseLocalServer();

            // Register the ASP.NET Core host.
            options.UseAspNetCore();
        });
#endregion

#region config swagger
services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetExecutingAssembly().GetName().Name, Version = "v1" });

    option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });

    // Set the comments path for the Swagger JSON and UI.**
    var xmlFile = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
    if (File.Exists(xmlFile))
    {
        option.IncludeXmlComments(xmlFile);
    }
    var projectDependencies = Assembly.GetEntryAssembly().CustomAttributes
        .SelectMany(c => c.ConstructorArguments.Select(ca => ca.Value?.ToString()))
        .Where(o => o != null)
        .ToList();
    foreach (var assembly in projectDependencies)
    {
        var otherXml = Path.Combine(AppContext.BaseDirectory, $"{assembly}.xml");
        if (File.Exists(otherXml))
        {
            option.IncludeXmlComments(otherXml);
        }
    }
    option.CustomSchemaIds(x => x.FullName);

});
#endregion

#region add services
services.AddScoped<IUserServices, UserServices>();
#endregion

services.AddHttpContextAccessor();
services.AddAuthorization();

var app = builder.Build();

if (!builder.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Assembly.GetExecutingAssembly().GetName().Name} v1");
        options.DocExpansion(DocExpansion.None);
    });
}

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

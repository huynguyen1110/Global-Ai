﻿//using Dapper;
//using GlobalAI.DataAccess.Base;
//using GlobalAI.Entities;
//using GlobalAI.Entities.Dto.RocketChat;
//using GlobalAI.FileDomain.Services;
//using GlobalAI.FileEntities.Settings;
//using GlobalAI.IdentityDomain.Implements;
//using GlobalAI.IdentityDomain.Interfaces;
//using GlobalAI.MSB.Configs;
//using GlobalAI.MSB.Services;
//using GlobalAI.RocketchatDomain.Implements;
//using GlobalAI.RocketchatDomain.Interfaces;
//using GlobalAI.Utils.ConfigModel;
//using GlobalAI.Utils.ConstantVariables.Shared;
//using GlobalAI.Utils.CustomException;
//using GlobalAI.Utils.Security;
//using GlobalAI.Utils.SharedApiService;
//using Hangfire;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Routing;
//using Microsoft.AspNetCore.SignalR;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using Oracle.EntityFrameworkCore.Diagnostics;
//using StackExchange.Profiling.Storage;
//using Swashbuckle.AspNetCore.SwaggerUI;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace GlobalAI.WebAPIBase
//{
//    /// <summary>
//    /// Start up base cho các sản phẩm
//    /// </summary>
//    public class StartUpProductBase
//    {
//        protected IEnumerable<string> ProjectDependencyNames = Assembly.GetEntryAssembly().CustomAttributes
//                                                                    .SelectMany(c => c.ConstructorArguments.Select(ca => ca.Value?.ToString()))
//                                                                    .Where(o => o != null)
//                                                                    .ToList();
//        protected IConfiguration Configuration { get; set; }

//        protected string MiniProfilerBasePath = string.Empty;
//        protected Action<IEndpointRouteBuilder> EndpointRouteBuilder = null;

//        public const string DbConnection = "GlobalAI";
//        public const string Redis = "Redis";
//        public const string Jwk = "Jwk";

//        public StartUpProductBase(IConfiguration configuration)
//        {
//            Configuration = configuration;
//            //DefaultTypeMap.MatchNamesWithUnderscores = true;
//            //EntityTypeMapper.InitEntityMapper();
//        }

//        /// <summary>
//        /// Configure các services
//        /// </summary>
//        /// <param name="services"></param>
//        public virtual void ConfigureServices(IServiceCollection services)
//        {
//            //services.AddOptions();
//            //services.AddHealthChecks();

//            //services.AddMemoryCache();
//            //services.AddMiniProfiler(options =>
//            //{
//            //    options.RouteBasePath = MiniProfilerBasePath; //profiler/results-index
//            //    (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);
//            //    options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
//            //}).AddEntityFramework();

//            services.AddSwaggerGen(option =>
//            {
//                option.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetExecutingAssembly().GetName().Name, Version = "v1" });

//                option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
//                {
//                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
//                    Name = "Authorization",
//                    BearerFormat = "JWT",
//                    In = ParameterLocation.Header,
//                    Type = SecuritySchemeType.ApiKey
//                });

//                option.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                    {
//                        new OpenApiSecurityScheme
//                        {
//                            Reference = new OpenApiReference
//                            {
//                                Type = ReferenceType.SecurityScheme,
//                                Id = JwtBearerDefaults.AuthenticationScheme
//                            }
//                        },
//                        Array.Empty<string>()
//                    }
//                });

//                // Set the comments path for the Swagger JSON and UI.**
//                var xmlFile = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
//                if (File.Exists(xmlFile))
//                {
//                    option.IncludeXmlComments(xmlFile);
//                }
//                var projectDependencies = Assembly.GetEntryAssembly().CustomAttributes
//                    .SelectMany(c => c.ConstructorArguments.Select(ca => ca.Value?.ToString()))
//                    .Where(o => o != null)
//                    .ToList();
//                foreach (var assembly in projectDependencies)
//                {
//                    var otherXml = Path.Combine(AppContext.BaseDirectory, $"{assembly}.xml");
//                    if (File.Exists(otherXml))
//                    {
//                        option.IncludeXmlComments(otherXml);
//                    }
//                }
//                option.CustomSchemaIds(x => x.FullName);

//                //add swagger signalR
//                List<Assembly> assemblyContainHub = new();
//                foreach (var dependency in ProjectDependencyNames)
//                {
//                    Assembly assembly = null;
//                    try
//                    {
//                        assembly = Assembly.Load(dependency);
//                    }
//                    catch
//                    {
//                    }

//                    if (assembly != null)
//                    {
//                        if (assembly.DefinedTypes.Any(dt => dt.BaseType?.FullName == "Microsoft.AspNetCore.SignalR.Hub"))
//                        {
//                            assemblyContainHub.Add(assembly);
//                        }
//                    }
//                }
//                if (assemblyContainHub.Count > 0)
//                {
//                    option.AddSignalRSwaggerGen(ssgOptions => ssgOptions.ScanAssemblies(assemblyContainHub));
//                }
//            });

//            services.AddAuthorization(options =>
//            {
//                options.AddScopeAPIPolicies();
//            });

//            services.AddAuthentication(options =>
//            {
//                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//            })
//            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
//            {
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateAudience = false,
//                    ValidateIssuer = false,
//                    ValidateLifetime = true,
//                    IssuerSigningKey = new JsonWebKey(File.ReadAllText(Configuration.GetValue<string>(Jwk)))
//                };
//                options.RequireHttpsMetadata = false;

//                options.Events = new JwtBearerEvents
//                {
//                    OnMessageReceived = context =>
//                    {
//                        //lấy token trong header
//                        var accessToken = context.Request.Query.FirstOrDefault(q => q.Key == "access_token").Value.ToString();
//                        if (string.IsNullOrEmpty(accessToken))
//                        {
//                            accessToken = context.Request.Headers.FirstOrDefault(h => h.Key == "access_token").Value.ToString();
//                        }

//                        // If the request is for our hub...
//                        var path = context.HttpContext.Request.Path;
//                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hub"))
//                        {
//                            // Read the token out of the query string
//                            context.Token = accessToken;
//                        }
//                        return Task.CompletedTask;
//                    }
//                };
//            });

//            services.AddControllers();

//            //nếu có cấu hình redis
//            string redisConnectionString = Configuration.GetConnectionString(Redis);

//            string connectionString = Configuration.GetConnectionString(DbConnection);
//            services.AddSingleton(new DatabaseOptions { ConnectionString = connectionString });

//            //entity framework
//            services.AddDbContext<GlobalAISchemaDbContext>(options =>
//            {
//                options.UseOracle(connectionString);
//                options.ConfigureWarnings(b =>
//                {
//                    b.Ignore(OracleEventId.DecimalTypeDefaultWarning);
//                });
//            }, ServiceLifetime.Scoped);

//            services.AddDbContext<GlobalAISchemaDbContextTransient>(options =>
//            {
//                options.UseOracle(connectionString);
//                options.ConfigureWarnings(b =>
//                {
//                    b.Ignore(OracleEventId.DecimalTypeDefaultWarning);
//                });
//            }, ServiceLifetime.Transient);

//            services.AddHttpContextAccessor();
//            services.AddDistributedMemoryCache();
//            services.AddSession();
//            services.AddDataProtection();

//            // Add Hangfire services.
//            services.AddHangfire(configuration =>
//            {
//                configuration
//                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
//                    .UseLog4NetLogProvider()
//                    .UseSimpleAssemblyNameTypeSerializer()
//                    .UseRecommendedSerializerSettings();
//                if (!string.IsNullOrWhiteSpace(redisConnectionString))
//                {
//                    configuration.UseRedisStorage(redisConnectionString, new Hangfire.Redis.RedisStorageOptions
//                    {
//                        Prefix = $"{{hangfire-{Assembly.GetExecutingAssembly().GetName().Name}}}:",
//                    });
//                }
//                else
//                {
//                    configuration.UseInMemoryStorage();
//                    // Add the processing server as IHostedService
//                    services.AddHangfireServer((service, options) =>
//                    {
//                        options.ServerName = Assembly.GetExecutingAssembly().GetName().Name;
//                        options.WorkerCount = 100;
//                    });
//                }
//            });

//            //signalR
//            var signalRBuilder = services.AddSignalR();
//            if (!string.IsNullOrWhiteSpace(redisConnectionString))
//            {
//                signalRBuilder.AddStackExchangeRedis(redisConnectionString, options =>
//                {
//                    options.Configuration.ChannelPrefix = $"{{SignalR-{Assembly.GetExecutingAssembly().GetName().Name}}}";
//                });
//            }

//            //service quyền
//            services.AddScoped<IPermissionServices, PermissionServices>();
//            services.AddScoped<IRocketChatServices, RocketChatServices>();
//        }

//        /// <summary>
//        /// Configure middleware
//        /// </summary>
//        /// <param name="app"></param>
//        /// <param name="env"></param>
//        /// <param name="loggerFactory"></param>
//        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
//        {
//            if (EnvironmentNames.DevelopEnv.Contains(env.EnvironmentName))
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseSwagger();
//                app.UseSwaggerUI(options =>
//                {
//                    options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Assembly.GetExecutingAssembly().GetName().Name} v1");
//                    options.DocExpansion(DocExpansion.None);
//                });
//            }

//            app.UseMiniProfiler();

//            //app.UseHttpsRedirection();
//            app.UseForwardedHeaders();
//            app.UseRouting();

//            app.UseAuthentication();
//            app.UseAuthorization();
//            app.UseSession();

//            app.UseHangfireDashboard();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//                endpoints.MapHealthChecks("/health");
//                endpoints.MapHangfireDashboard("/hangfire");
//                EndpointRouteBuilder?.Invoke(endpoints);
//            });
//            loggerFactory.AddLog4Net();
//        }

//        /// <summary>
//        /// Tự tìm trong các Project Dependencies xem có định nghĩa class AutoMapProfile nào không nếu có thì thêm vào hàm AddAutoMapper
//        /// </summary>
//        /// <param name="services"></param>
//        public void ConfigureAutoMap(IServiceCollection services)
//        {
//            //var test = Assembly.GetEntryAssembly();
//            //var test2 = Assembly.GetExecutingAssembly();
//            //var test3 = Assembly.GetCallingAssembly();
//            //var test4 = AppDomain.CurrentDomain;

//            List<Type> autoMapProfiles = new();

//            foreach (var dependency in ProjectDependencyNames)
//            {
//                Assembly assembly = null;
//                //thử load assembly
//                try
//                {
//                    assembly = Assembly.Load(dependency);
//                }
//                catch
//                {
//                }

//                if (assembly != null)
//                {
//                    var getAutoMapProfiles = assembly.DefinedTypes.Where(dt => dt.BaseType?.FullName == "AutoMapper.Profile")
//                        .Select(o => o.AsType())
//                        .ToList();
//                    autoMapProfiles.AddRange(getAutoMapProfiles);
//                }
//            }

//            services.AddAutoMapper(autoMapProfiles.ToArray());
//        }

//        /// <summary>
//        /// Config filter validation model trả ra lỗi 400 nếu model invalid
//        /// </summary>
//        /// <param name="services"></param>
//        public void ConfigureControllerCustomValidation(IServiceCollection services)
//        {
//            services.AddControllers(options =>
//                options.Filters.Add(typeof(CustomValidationError))
//            );
//        }

//        /// <summary>
//        /// Config kết nối Msb gồm appsetting và các service thu hộ chi hộ truy vấn
//        /// </summary>
//        /// <param name="services"></param>
//        public void ConfigureMsb(IServiceCollection services)
//        {
//            services.Configure<MsbConfiguration>(Configuration.GetSection("Msb"));
//            //thu hộ
//            services.AddScoped<MsbCollectMoneyServices>();
//            //chi hộ
//            services.AddScoped<MsbPayMoneyServices>();
//            //truy vấn
//            services.AddScoped<MsbInquiryServices>();
//        }

//        /// <summary>
//        /// Config Shared api gồm appsetting và SharedMediaApiUtils
//        /// </summary>
//        /// <param name="services"></param>
//        public void ConfigureSharedApi(IServiceCollection services)
//        {
//            services.Configure<SharedApiConfiguration>(Configuration.GetSection("SharedApi"));
//            services.AddScoped<SharedMediaApiUtils>();
//            services.AddScoped<SharedNotificationApiUtils>();
//            services.AddScoped<SharedSignServerApiUtils>();
//        }

//        /// <summary>
//        /// Config file gồm appsetting và FileServices
//        /// </summary>
//        /// <param name="services"></param>
//        public void ConfigureFile(IServiceCollection services)
//        {
//            //config file
//            services.Configure<FileConfig>(Configuration.GetSection("FileConfig:File"));
//            services.Configure<ImageConfig>(Configuration.GetSection("FileConfig:Image"));
//            services.Configure<IdFileConfig>(Configuration.GetSection("FileConfig:IdFile"));

//            services.AddScoped<IFileServices, FileServices>();
//        }
//    }
//}

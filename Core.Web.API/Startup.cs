using Autofac;
using Core.Business;
using Core.Common.Configuration;
using Core.Common.Settings;
using Core.Web.Api.Filters;
using ElmahCore;
using ElmahCore.Mvc;
using Microsoft.OpenApi.Models;
using NetCore.AutoRegisterDi;
using Newtonsoft.Json;
using System.Reflection;

namespace Core.Web.Api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            InitSettings();
            var assembliesToScan = new[] {
                Assembly.GetExecutingAssembly(),
                Assembly.GetAssembly(typeof(Core.Business.IDependency)),
                Assembly.GetAssembly(typeof(Core.Data.IDependency)),
            };
            // register services only
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository")).AsPublicImplementedInterfaces();
            //  services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan).AsPublicImplementedInterfaces();

            services.AddHttpContextAccessor();

            var ioc = new IoC(() => {
                var builder = new ContainerBuilder();
                builder.RegisterAssemblyTypes(assembliesToScan)
                    .Where(c => c.Name.EndsWith("Service") ||
                                c.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces();
                return builder.Build();
            });

            //var ioc = new IoC(() => {
            //    var builder = new ContainerBuilder();
            //    builder.RegisterAssemblyTypes(assembliesToScan)
            //        .AsImplementedInterfaces();
            //    return builder.Build();
            //});

            services.AddSwaggerGen(c => {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RLV Core API V1", Version = "v1" });

                // Authorization header
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Description = @"Authorization header using the Bearer scheme. <br/>
                      Enter 'Bearer' [space] and then your token in the text input below.
                      <br/> Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityDefinition("token", new OpenApiSecurityScheme {
                    Description = @"JWT user encrypted token header",
                    Name = "token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                      },
                      Scheme = "oauth2",
                      Name = "Bearer",
                      In = ParameterLocation.Header,

                    },
                    new List<string>()
                  }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id = "token"
                      },
                      Scheme = "oauth2",
                      Name = "token",
                      In = ParameterLocation.Header,

                    },
                    new List<string>()
                  }
                });

                //// Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            services.AddCors(options => {
                options.AddPolicy("AllowedOrigins",
                        builder => {
                            builder.AllowAnyMethod().AllowAnyHeader();
                            //if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["AllowedOrigins"]) && CoreConfigurationManager.AppSettings["AllowedOrigins"] != "*")
                            if (!string.IsNullOrWhiteSpace(GlobalSettings.AllowedOrigins) && GlobalSettings.AllowedOrigins != "*") {
                                builder.WithOrigins(GlobalSettings.AllowedOrigins.Split(','));
                            } else {
                                builder.AllowAnyOrigin();
                            }
                        });
            });

            services.AddMvc().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            });

            services.AddControllers();
            //services.AddControllers(config => {
            //    config.Filters.Add(new LoggingFilter());
            //});

            //services.AddElmah();
            services.AddElmah<XmlFileErrorLog>(options => {
                options.LogPath = "~/ElmahLog"; // OR options.LogPath = "с:\errors";
                options.FiltersConfig = "elmah.xml";
            });

            ActiveBackgroundServices(services);
        }



        /// <summary>
        ///  this to activate background services CoreConfigurationManager.AppSettings["DefaultConnectionName"];
        /// </summary>
        /// <param name="services"></param>
        private void ActiveBackgroundServices(IServiceCollection services) {

            //var enabledServices = CoreConfigurationManager.AppSettings[ConfigurationKeys.EnabledBackgroundServices.ToString()]
            //    .Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            //if (enabledServices.Contains(BackgroundServiceNames.ContactActionQueueProcessorService)) {
            //    services.AddSingleton<IScheduledTask, ContactActionQueueProcessorService>();
            //}

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            app.UseCors("AllowedOrigins");

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CCS API V1");
            });
            app.UseElmah();
            IoC.ServiceProvider = app.ApplicationServices;

            //var backgroundJobScheduler = new BackgroundJobScheduler();
            //backgroundJobScheduler.InitializeBackgroundJobs();

            app.UseHttpsRedirection();

        }

        private void InitSettings() {
            const string CONNECTIONS_SECTION = "ConnectionStrings";
            const string APPSETTINGS_SECTION = "AppSettings";
            //Connections
            if (Configuration.GetSection(CONNECTIONS_SECTION).Exists()) {
                foreach (var item in Configuration.GetSection(CONNECTIONS_SECTION).AsEnumerable()) {
                    var key = item.Key.Replace(CONNECTIONS_SECTION, "");
                    if (!string.IsNullOrWhiteSpace(key)) {
                        CoreConfigurationManager.ConnectionStrings.Add(key.TrimStart(':'), new ConfigConnection { ConnectionString = item.Value });
                    }
                }
            }

            //AppSettings
            if (Configuration.GetSection(APPSETTINGS_SECTION).Exists()) {
                foreach (var item in Configuration.GetSection(APPSETTINGS_SECTION).AsEnumerable()) {
                    var key = item.Key.Replace(APPSETTINGS_SECTION, "");
                    if (!string.IsNullOrWhiteSpace(key)) {
                        CoreConfigurationManager.AppSettings.Add(key.TrimStart(':'), item.Value);
                    }
                }
            }
        }
    }


}

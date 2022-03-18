using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using mapun_api.Models;
using mapun_api.Services;
using mapun_api.Data;
using GraphQL.Server.Ui.Voyager;
using HotChocolate.Data.Filters;
using HotChocolate.Execution.Options;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.NodaTime;
using HotChocolate.Types.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NodaTime;
using NodaTime.Extensions;
using NodaTime.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.FileProviders;
using mapun_api.GQL.Query;
using mapun_api.GQL.Mutation;

namespace mapun_api
{
    public class Startup
    {

        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpContextAccessor();

            services.AddPooledDbContextFactory<AppDbContext>(opt =>
            {
                opt.UseSqlServer
                    (Configuration.GetConnectionString("CommandConStr"), x => x.UseNodaTime());
                opt.EnableSensitiveDataLogging();
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            });

            services.AddDbContextPool<AppDbContext>(opt =>
            {
                opt.UseSqlServer
                    (Configuration.GetConnectionString("CommandConStr"), x => x.UseNodaTime());
                opt.EnableSensitiveDataLogging();
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });



            services.AddControllers();

            services.AddFluentEmail("noreply@timefree.ph", "No Reply")
                .AddLiquidRenderer(options =>
                {
                    options.FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Templates/Email"));
                })
                .AddSmtpSender(new SmtpClient
                {
                    Credentials = new NetworkCredential(Configuration.GetValue<string>("smtp:username"), Configuration.GetValue<string>("smtp:password")),
                    Host = "smtp.office365.com",
                    Port = 587,
                    EnableSsl = true
                });


            services.Configure<AppSettings>(Configuration);

            //services.AddMultiTenant<TenantInfo>()
            // .WithHostStrategy()
            // .WithConfigurationStore();


            services.AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    // only for testing
                    cfg.RequireHttpsMetadata = false;
                    cfg.Authority = Configuration["KeyCloak"];
                    cfg.IncludeErrorDetails = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["KeyCloak"],
                        ValidateLifetime = true,
                    };
                    cfg.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();
                            c.Response.StatusCode = 401;
                            c.Response.ContentType = "text/plain";
                            return c.Response.WriteAsync(c.Exception.ToString());
                        }
                    };
                });

            services.AddAuthorization();

            services
                .AddGraphQLServer()
                .SetRequestOptions(_ => new RequestExecutorOptions { ExecutionTimeout = TimeSpan.FromMinutes(10) })
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<UploadType>()
                .AddType<LocalDateType>()
                .AddType<LocalDateTimeType>()
                .AddType<LocalTimeType>()
                .AddType<InstantType>()
                .AddType<OffsetDateTimeType>()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddAuthorization()
                .AddType(new UuidType('D'))
                // .AddConvention<INamingConventions>(new GraphQLNamingConvention())
                .AddConvention<IFilterConvention>(new FilterConventionExtension(configure =>
                {
                    configure.BindRuntimeType<Instant, ComparableOperationFilterInputType<Instant>>();
                    configure.BindRuntimeType<Instant?, ComparableOperationFilterInputType<Instant?>>();
                    configure.BindRuntimeType<LocalDate, ComparableOperationFilterInputType<LocalDate>>();
                    configure.BindRuntimeType<LocalDate?, ComparableOperationFilterInputType<LocalDate?>>();
                    configure.BindRuntimeType<LocalDateTime, ComparableOperationFilterInputType<LocalDateTime>>();
                    configure.BindRuntimeType<LocalDateTime?, ComparableOperationFilterInputType<LocalDateTime?>>();
                    configure.BindRuntimeType<OffsetDateTime, ComparableOperationFilterInputType<OffsetDateTime>>();
                    configure.BindRuntimeType<OffsetDateTime?, ComparableOperationFilterInputType<OffsetDateTime?>>();
                    configure.BindRuntimeType<Duration, ComparableOperationFilterInputType<Duration>>();
                    configure.BindRuntimeType<Duration?, ComparableOperationFilterInputType<Duration?>>();
                    configure.BindRuntimeType<Period, ComparableOperationFilterInputType<Period>>();
                    configure.BindRuntimeType<Period?, ComparableOperationFilterInputType<Period?>>();
                    configure.BindRuntimeType<LocalTime, ComparableOperationFilterInputType<LocalTime>>();
                    configure.BindRuntimeType<LocalTime?, ComparableOperationFilterInputType<LocalTime?>>();
                }))
                .SetPagingOptions(
                    new PagingOptions
                    {
                        IncludeTotalCount = true
                    })
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);



            // services.AddSwaggerGen(c =>
            // {
            //     c.OperationFilter<FileContentResultTypeAttribute.FileResultContentTypeOperationFilter>();
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "xborg_api", Version = "v1" });
            // });

            Dapper.SqlMapper.AddTypeHandler(new DapperInstantHandler());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }
            // TODO: Revert to no Exception
            app.UseDeveloperExceptionPage();

            // app.UseMultiTenant();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("api", "api/{controller}/{action}/{id?}");
                endpoints.MapGraphQL();
                endpoints.MapDefaultControllerRoute();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shell Convert v1"));

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            });

        }
    }
}

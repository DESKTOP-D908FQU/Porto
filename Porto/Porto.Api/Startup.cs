using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Porto.Api
{
    using NSwag.AspNetCore;
    using Porto.Api.Options;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddControllers();

            var apiVersionOptions = Configuration.GetSection(ApiVersionOptions.Position).Get<ApiVersionOptions>();
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = apiVersionOptions.ReportApiVersions;
                options.AssumeDefaultVersionWhenUnspecified = apiVersionOptions.AssumeDefaultVersionWhenUnspecified;
                options.DefaultApiVersion = apiVersionOptions.DefaultApiVersion;
                options.ApiVersionReader = apiVersionOptions.ApiVersionReader;
            }).AddVersionedApiExplorer(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = apiVersionOptions.AssumeDefaultVersionWhenUnspecified;
                options.DefaultApiVersion = apiVersionOptions.DefaultApiVersion;
                options.GroupNameFormat = apiVersionOptions.GroupNameFormat;
                options.SubstituteApiVersionInUrl = apiVersionOptions.SubstituteApiVersionInUrl;
            });

            var apiSwaggerOptions = Configuration.GetSection(ApiSwaggerOptions.Position).Get<ApiSwaggerOptions>();
            services.AddSwaggerDocument((configure, serviceProvider) =>
            {
                configure.DocumentName = apiSwaggerOptions.DocumentName;
                configure.ApiGroupNames = apiSwaggerOptions.ApiGroupNames;

                configure.GenerateEnumMappingDescription = apiSwaggerOptions.GenerateEnumMappingDescription;

                configure.PostProcess = document =>
                {
                    document.Info.Title = apiSwaggerOptions.Title;
                    document.Info.Version = apiSwaggerOptions.Version;
                    document.Info.Description = apiSwaggerOptions.Description;
                    document.Info.TermsOfService = apiSwaggerOptions.TermsOfService;
                    document.Info.Contact = apiSwaggerOptions.Contact;
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3(options =>
            {
                foreach (var description in apiVersionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerRoutes.Add(new SwaggerUi3Route($"{description.GroupName}", $"/swagger/{description.GroupName}/swagger.json"));
                }
            });
        }
    }
}

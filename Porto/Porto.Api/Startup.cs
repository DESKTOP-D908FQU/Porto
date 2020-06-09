using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Porto.Api
{
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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
        }
    }
}

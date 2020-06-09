using NSwag;

namespace Porto.Api.Options
{
    public class ApiSwaggerOptions
    {
        public const string Position = "SwaggerApplication";

        public string Title { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public string DocumentName { get; set; }

        public string TermsOfService { get; set; }

        public bool GenerateEnumMappingDescription { get; set; }

        public string[] ApiGroupNames { get; set; }

        public string ContactEmail { get; set; }

        public string ContactName { get; set; }

        public string ContactUrl { get; set; }

        public OpenApiContact Contact => new OpenApiContact
        {
            Name = ContactName,
            Email = ContactEmail,
            Url = ContactUrl,
        };
    }
}

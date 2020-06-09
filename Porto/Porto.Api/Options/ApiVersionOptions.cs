using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Porto.Api.Options
{
    public class ApiVersionOptions
    {
        public const string Position = "DefaultApiVersion";

        public int Major { get; set; }

        public int Minor { get; set; }

        public ApiVersion DefaultApiVersion => new ApiVersion(Major, Minor);

        public bool ReportApiVersions { get; set; }

        public bool AssumeDefaultVersionWhenUnspecified { get; set; }

        public string GroupNameFormat { get; set; }

        public bool SubstituteApiVersionInUrl { get; set; }

        public UrlSegmentApiVersionReader ApiVersionReader => new UrlSegmentApiVersionReader();
    }
}

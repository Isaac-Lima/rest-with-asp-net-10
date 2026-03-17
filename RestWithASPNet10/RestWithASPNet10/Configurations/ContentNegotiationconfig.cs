using Microsoft.Net.Http.Headers;

namespace RestWithASPNet10.Configurations
{
    public static class ContentNegotiationconfig
    {
        public static IMvcBuilder AddContentNegotiation(this IMvcBuilder builder)
        {
            return builder.AddMvcOptions(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).
            AddXmlSerializerFormatters();
        }
    }
}

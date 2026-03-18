using ECommerce.WebUI.Services.CatalogServices.CategoryServices;
using ECommerce.WebUI.Services.DiscountServices.CouponServices;
using ECommerce.WebUI.Services.IdentityServices;
using ECommerce.WebUI.Settings;
using System.Net.Http.Headers;

namespace ECommerce.WebUI.Extensions
{
    public static class HttpClientServices
    {
        public static void AddHttpClientServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServiceApiSettings>(configuration.GetSection(nameof(ServiceApiSettings)));
            var apiSettings = configuration.GetSection(nameof(ServiceApiSettings)).Get<ServiceApiSettings>();

            services.Configure<ClientSettings>(configuration.GetSection(nameof(ClientSettings)));

            services.AddHttpClient<ICategoryService, CategoryService>(client =>
            {
                client.BaseAddress = new Uri(apiSettings.ApiGatewayUrl + apiSettings.Catalog.Path);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");
            });

            services.AddHttpClient<ICouponServices, CouponServices>(client =>
            {
                client.BaseAddress = new Uri(apiSettings.ApiGatewayUrl + apiSettings.Discount.Path);
            });

            //services.AddHttpClient<IIdentityService, IdentityService>();
        }
    }
}

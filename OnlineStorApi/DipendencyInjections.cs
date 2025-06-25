using Application.Services;

using OnlineStorAccess.Services;

namespace OnlineStorApi
{
    public static class DipendencyInjections

    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
          

            //Register your services here
            services.AddScoped<CustomerService>();
            services.AddScoped<InventoryService>();
            services.AddScoped<InvoicesServices>();
            services.AddScoped<ItemGalleryService>();
            services.AddScoped<ItemService>();
            services.AddScoped<OrderService>();
            services.AddScoped<PersonService>();
            services.AddScoped<PurchasHistoryService>();
            services.AddScoped<ReviewService>();
            services.AddScoped<SalesService>();
            services.AddScoped<UserService>();


            return services;
        }

    }
}

using Bookshop.Domain.Interfaces.Services;
using Bookshop.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshop.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();

            return services;
        }
    }
}

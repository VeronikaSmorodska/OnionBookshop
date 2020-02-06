using Bookshop.Domain.Interfaces.Services;
using Bookshop.Service.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bookshop.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

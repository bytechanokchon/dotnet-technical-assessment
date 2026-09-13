using Applications.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Applications
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // สแกนหา Command, Query, Handler ทั้งหมดที่อยู่ใน Assembly (Project) นี้โดยอัตโนมัติ
            services.AddMediatR(configs =>
            {
                configs.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            return services;
        }
    }
}

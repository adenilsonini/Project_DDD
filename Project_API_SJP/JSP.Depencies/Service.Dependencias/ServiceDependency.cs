using JSP.Domain.Authorization;
using JSP.Domain.Interfaces;
using JSP.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace JSP.Depencies.Service.Dependencias
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IServiceUserApp, UserServiceApp>();

            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddScoped<IServiceUserLoginApp, UserServiceLoginApp>();

        }
    }
}

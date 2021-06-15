using JSP.Domain.Interfaces;
using JSP_Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace JSP.Depencies.Service.Dependencias
{
    public static class MySqlRepositoryDependency
    {
        public static void AddMySqlRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryUser, UserRepositoryMy>();

            services.AddScoped<IRepositoryLoginApp, UserLoginRepositoryMy>();
        }
    }
}

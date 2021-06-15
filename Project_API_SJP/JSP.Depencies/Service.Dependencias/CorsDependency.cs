using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

namespace JSP.Depencies.Service.Dependencias
{
    public static class CorsDependency
    {
        public static void AddCorsDependency(this IServiceCollection services)
        {
            services.AddCors();
        }

        public static void UseCorsDependency(this IApplicationBuilder app)
        {

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


        }
    }
}

using Aplication.Interfaces.Firebase.Authentication;
using Infraestructure.Services.Firebase.Auth;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthService,AuthService>();
        }
    }
}

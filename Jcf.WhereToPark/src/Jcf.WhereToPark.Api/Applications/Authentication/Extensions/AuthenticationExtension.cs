﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Jcf.WhereToPark.Api.Applications.Authentication.Extensions
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Jwt:Key"])),
                        ValidAudience = configuration["Authentication:Jwt:Audience"],
                        ValidIssuer = configuration["Authentication:Jwt:Issuer"],
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                    };
                });

            return services;
        }
    }
}

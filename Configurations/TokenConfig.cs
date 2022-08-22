using EscolaAPI.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EscolaAPI.Configurations
{
    public static class TokenConfig
    {

        public static void AddTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string SecretKeyConfig = configuration.GetSection("secretKey").Value;
            byte[] secretKey = Encoding.ASCII.GetBytes(SecretKeyConfig);
            services.AddAuthentication(Opt =>
            {
                Opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Opt =>
            {
                Opt.RequireHttpsMetadata = false;
                Opt.SaveToken = true;
                Opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };
            });


        }
    }
}

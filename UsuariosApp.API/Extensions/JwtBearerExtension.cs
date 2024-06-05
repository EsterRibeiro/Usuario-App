using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UsuariosApp.API.Services;

namespace UsuariosApp.API.Extensions
{
    /// <summary>
    /// Classe de extensão para definirmos a politica 
    /// de autenticação desta API (Token JWT -> Bearer TOKEN)
    /// </summary>
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearerConfig(this IServiceCollection services)
        {
            //Criando a política de autenticação definindo o JWT como mecanismo
            //de autenticação e autorização de usuários do projeto
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //definindo como o projeto deverá validar os TOKENS
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    //validar se os TOKENS recebidos pela nossa API estão assinados
                    //com a mesma chave secreta que usamos para criar os TOKENS
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(JwtBearerService.SecretKey))
                };
            });

            return services;
        }
    }
}





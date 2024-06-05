using UsuarioApp.Infra.Data.Repositories;
using UsuariosApp.Domain.Interfaces.Producers;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Message.Consumers;
using UsuariosApp.Infra.Message.Producers;

namespace UsuariosApp.API.Extensions
{
    /// <summary>
    /// Classe de extensão para as configurações de injeção de dependência
    /// do sistema (mapeamento das interfaces e suas respectivas classes)
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPerfilRepository, PerfilRepository>();
            services.AddTransient<IMessageProducer, MessageProducer>();
            services.AddHostedService<MessageConsumer>();

            return services;
        }
    }
}


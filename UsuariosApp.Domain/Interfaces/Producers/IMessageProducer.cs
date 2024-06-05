using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Models;

namespace UsuariosApp.Domain.Interfaces.Producers;
public interface IMessageProducer
{
    void EnviarMensagem(NotificacaoEmailModel notificacao);
}

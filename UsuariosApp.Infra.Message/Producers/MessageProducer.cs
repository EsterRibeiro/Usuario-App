using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Producers;
using UsuariosApp.Domain.Models;
using UsuariosApp.Infra.Message.Settings;

namespace UsuariosApp.Infra.Message.Producers;

/// <summary>
/// Classe para conectar no servidor da mensageria
/// e gravar mensagens na fila (incluir itens na fila)
/// </summary>
public class MessageProducer : IMessageProducer
{
    public void EnviarMensagem(NotificacaoEmailModel model)
    {
        #region Conectando no servidor do RabbitMQ

        var connectionFactory = new ConnectionFactory
        {
            Uri = new Uri(RabbitMQSettings.Url) //conectar no servidor da mensageria
        };

        #endregion

        #region Acessando a fila e gravando a msg
        using (var connection = connectionFactory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                        queue: RabbitMQSettings.Queue, //nome da fila
                        durable: true, //fila que não é apagada
                        exclusive: false, //fila não é exclusiva deste projeto
                        autoDelete: false, //fila não exclui mensagens automaticamente
                        arguments: null
                        );

                //escrevendo a mensagem na fila
                channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: RabbitMQSettings.Queue,
                    basicProperties: null,
                    body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model))
                    );

            }
        }
        #endregion
    }
}

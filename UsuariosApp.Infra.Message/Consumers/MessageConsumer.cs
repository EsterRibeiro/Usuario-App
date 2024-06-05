using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using UsuariosApp.Domain.Models;
using UsuariosApp.Infra.Logs.Collections;
using UsuariosApp.Infra.Logs.Persistence;
using UsuariosApp.Infra.Message.Helpers;
using UsuariosApp.Infra.Message.Settings;

namespace UsuariosApp.Infra.Message.Consumers;
/// <summary>
/// Classe para ler cada mensagem contida na fila
/// e realizado o envio de mensagem por e-mail
/// </summary>
public class MessageConsumer : BackgroundService
{
    #region Atributos
    private readonly IServiceProvider? _serviceprovider;
    private readonly IConnection? _connection;
    private readonly IModel? _model;

    #endregion

    #region Método construtor

    public MessageConsumer(IServiceProvider? serviceProvider)
    {
        _serviceprovider = serviceProvider;

        var connectionFactory = new ConnectionFactory
        {
            Uri = new Uri(RabbitMQSettings.Url),
        };

        //conectando na fila para fazer leitura das mensagens
        _connection = connectionFactory.CreateConnection();
        _model = _connection.CreateModel();
        _model?.QueueDeclare(
            queue: RabbitMQSettings.Queue,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
            );
    }

    #endregion

    //executar a leitura da fila
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //criando um objeto para ler o conteúdo da fila
        var consumer = new EventingBasicConsumer(_model);

        //realizando a leitura
        consumer.Received += (sender, args) =>
        {
            var contentArray = args.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(contentArray);

            //deserializar a mensagem (JSON -> OBJETO)
            var emailModel = JsonConvert.DeserializeObject<NotificacaoEmailModel>(contentString);

            #region Enviar email para o usuário

            using (var scope = _serviceprovider.CreateScope())
            {
                var logMensagens = new LogMensagens()
                {
                    Id = Guid.NewGuid(),
                    DataHora = DateTime.Now
                };

                try
                {
                    //TODO Enviar o e-mail para o usuário
                    MailHelper.Send(emailModel);

                    logMensagens.Status = "Sucesso";
                    logMensagens.Descricao = $"Email enviado com sucesso para: {emailModel.EmailDestinatario}";

                }
                catch (Exception e)
                {
                    logMensagens.Status = "Erro";
                    logMensagens.Descricao = $"Falha ao enviar o email para: {emailModel.EmailDestinatario}";

                }
                finally
                {
                    var logMensagensPersistence = new LogMensagensPersistence();
                    logMensagensPersistence.Insert(logMensagens);

                    //retirar a mensagem da fila
                    _model.BasicAck(args.DeliveryTag, false);
                }
            }

            #endregion
        };

        _model?.BasicConsume(RabbitMQSettings.Queue, false, consumer);
        return Task.CompletedTask;  
    }
}

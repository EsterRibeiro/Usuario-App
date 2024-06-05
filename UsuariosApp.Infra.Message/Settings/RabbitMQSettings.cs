namespace UsuariosApp.Infra.Message.Settings;

//Classe para configurarmos os parâmetros de conexão do RabbitMQ
public class RabbitMQSettings
{
    //URL para conexão com o servidor RabbitMQ
    public static string Url = "amqps://xqeqvbiy:a_8no0x4U493j2JR9tceomlW52B-1teq@jackal.rmq.cloudamqp.com/xqeqvbiy";

    public static string Queue = "emails_usuario";
}

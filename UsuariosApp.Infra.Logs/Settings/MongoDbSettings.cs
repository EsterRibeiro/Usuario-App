namespace UsuariosApp.Infra.Logs.Settings;

/// <summary>
/// Classe para configurar os parâmetros de conexão com o mongoDB
/// </summary>
public class MongoDbSettings
{

    //Caminho do servidor do banco de dados
    public static string Host => "mongodb://localhost:27017/";

    //nome do banco de dados do mongoDB
    public static string Database => "DBLog";

    //indicar se será utilizado criptografia de rede
    public static bool isSSL => false;
}

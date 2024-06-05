using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Infra.Logs.Collections;
using UsuariosApp.Infra.Logs.Settings;

namespace UsuariosApp.Infra.Logs.Contexts;

/// <summary>
/// Classe para conexão com o banco de dados do MongoDB
/// </summary>
public class MongoDbContext
{
    /// <summary>
    /// Atributo para guardar a conexão do banco de dados
    /// </summary>
    private IMongoDatabase _mongoDatabase;

    //método construtor
    public MongoDbContext()
    {
        //caminho do servidor do banco de dados
        var mongoClient = MongoClientSettings.FromUrl(new MongoUrl(MongoDbSettings.Host));

        //verificar se a conexão usa SSL 0> Security Socket Layer
        if (MongoDbSettings.isSSL)
        {
            mongoClient.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
            };
        }

        //abrindo a conexão com o banco de dados do MongoDB
        var client = new MongoClient(mongoClient);
        _mongoDatabase = client.GetDatabase(MongoDbSettings.Database);
    }

    //mapear cada collection do banco de dados
    public IMongoCollection<LogMensagens> LogMensagens
        => _mongoDatabase.GetCollection<LogMensagens>("LogMensagens");


}



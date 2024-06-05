using MongoDB.Driver;
using UsuariosApp.Infra.Logs.Collections;
using UsuariosApp.Infra.Logs.Contexts;

namespace UsuariosApp.Infra.Logs.Persistence;

/// <summary>
/// Classe de persistência de dados para gravar, alterar, excluir e consultar
/// registros na collection de log de mensagens do MongoDB (é como o repositório do banco relacional)
/// </summary>
public class LogMensagensPersistence
{
    private MongoDbContext _mongoDbContext => new MongoDbContext();

    //método para gravar 1 registro na collection do mongoDB
    public void Insert(LogMensagens logMensagens)
    {
        _mongoDbContext.LogMensagens.InsertOne(logMensagens);
    }

    //método para atualizar 1 registro na collection do mongoDb
    public void Update(LogMensagens logMensagens)
    {
        _mongoDbContext.LogMensagens.ReplaceOne(
            Builders<LogMensagens>.Filter.Eq(
                log => log.Id, logMensagens.Id),logMensagens
            );
    }

    /// <summary>
    /// Método para excluir 1 registro na collection do MongoDB
    /// </summary>
    public void Delete(Guid id)
    {
        _mongoDbContext.LogMensagens.DeleteOne(
            Builders<LogMensagens>.Filter.Eq(log => log.Id, id)
            );
    }

    /// <summary>
    /// Método para retornar todos os logs dentro de um período de datas
    /// </summary>
    public List<LogMensagens> GetAll(DateTime dataInicio, DateTime dataFim)
    {
        return _mongoDbContext.LogMensagens.Find(
            Builders<LogMensagens>.Filter.And(
                Builders<LogMensagens>.Filter.Gte(log => log.DataHora, dataInicio), //Greather than or equal
                Builders<LogMensagens>.Filter.Lte(log => log.DataHora, dataFim) //Less than or equal
                )
            ).ToList();
    }


    /// <summary>
    /// Método para retornar 1 log baseado no ID
    /// </summary>
    public LogMensagens GetById(Guid id)
    {
        return _mongoDbContext.LogMensagens.Find(
            Builders<LogMensagens>.Filter.Eq(log => log.Id, id)
            ).FirstOrDefault();
    }
}


using Dapper;
using Microsoft.EntityFrameworkCore;
using UsuarioApp.Infra.Data.Contexts;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Repositories;

namespace UsuarioApp.Infra.Data.Repositories;

/// <summary>
/// reposi´tório de banco de dados para operações de perfil
/// </summary>
public class PerfilRepository : IPerfilRepository
{
    Perfil? IPerfilRepository.GetById(Guid id)
    {
        //abrindo conexão com o bd
        using (var dataContext = new DataContext())
        {
            //capturando a conexão aberta com o banco de dados
            var connection = dataContext.Database.GetDbConnection();
            var sql = "select * from perfil where id=@id";

            //executando um comando SQL no banco de dados
            return connection.Query<Perfil>(sql, new { id }).FirstOrDefault();
        }
    }

    public Perfil? GetByNome(string nome)
    {
        var sql = "select * from perfil where nome=@nome";
        using (var dataContext = new DataContext())
        {
            //capturando a conexão aberta com o BD
            var connection = dataContext.Database.GetDbConnection();

            //executando um comando sql no BD
            return connection.Query<Perfil>(sql, new { nome }).FirstOrDefault();
        }
    }

}

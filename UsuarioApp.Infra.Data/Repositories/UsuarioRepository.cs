using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Infra.Data.Contexts;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Repositories;

namespace UsuarioApp.Infra.Data.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    public void Add(Usuario usuario)
    {
        using (var dataContext = new DataContext())
        {
            dataContext.Add(usuario);
            dataContext.SaveChanges();
        }
    }

    public Usuario? GetByEmail(string email)
    {
        var sql = "select * from usuario where email = @email";

        using (var dataContext = new DataContext())
        {
            var connection = dataContext.Database.GetDbConnection();

            return connection.Query<Usuario>(sql, new { email})
                .FirstOrDefault();
        }
    }

    public Usuario? GetByEmailAndPassword(string email, string senha)
    {
        var sql = "select * from usuario where email=@email and senha=@senha";

        using (var dataContext = new DataContext())
        {
            var connection = dataContext.Database.GetDbConnection();

            return connection.Query<Usuario>(sql, new { email, senha })
                .FirstOrDefault();
        }
    }


    public Usuario? GetById(Guid id)
    {
        //SELECT* FROM USUARIO u
        //INNER JOIN PERFIL p
        //ON p.ID = u.PERFIL_ID
        //WHERE u.ID = 'A83DBE1E-F586-433D-ABAD-F6DDD9C21BE4';



        using (var dataContext = new DataContext())
        {

            //LAMBDA
            //return dataContext.Set<Usuario>()
            //    .Include(u => u.Perfil) //INNER JOIN
            //    .Where(u => u.Id == id)
            //    .FirstOrDefault();


            //DAPPER
            //capturando a conexão com o banco de dados
            var connection = dataContext.Database.GetDbConnection();

            //variável para escrevermos a consulta SQL
            var query = @"
                    SELECT * FROM USUARIO u
                    INNER JOIN PERFIL p
                    ON p.ID = u.PERFILID
                    WHERE u.ID = @id;
                ";

            //executando a consulta com o DAPPER
            return connection.Query(query, (Usuario u, Perfil p) =>
            {
                u.Perfil = p; //JOIN (Associação)
                return u;
            },
            new { id },
            splitOn: "PERFILID") //Chave estrangeira
            .FirstOrDefault(); //retornar o primeiro registro encontrado
        }

    }
}


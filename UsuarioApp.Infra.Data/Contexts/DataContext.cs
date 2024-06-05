using Microsoft.EntityFrameworkCore;
using UsuarioApp.Infra.Data.Mappings;

namespace UsuarioApp.Infra.Data.Contexts;

/// <summary>
/// Classe de contexto para conexão com o banco de dados
/// </summary>
public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsuariosAppBD;Integrated Security=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PerfilMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
    }
}

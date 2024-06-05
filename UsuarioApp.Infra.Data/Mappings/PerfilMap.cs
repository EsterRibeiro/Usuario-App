using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Entities;

namespace UsuarioApp.Infra.Data.Mappings;

/// <summary>
/// Classe de mapeamento de entidade
/// </summary>
public class PerfilMap : IEntityTypeConfiguration<Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> builder)
    {
        builder.ToTable("Perfil");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(50).IsRequired();

        builder.HasIndex(p => p.Nome).IsUnique();//é um campo único

    }
}

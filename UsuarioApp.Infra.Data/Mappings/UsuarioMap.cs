using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuarioApp.Infra.Data.Mappings;
public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id");
        builder.Property(u => u.Nome).HasColumnName("Nome").HasMaxLength(50).IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").HasMaxLength(50).IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Senha).HasColumnName("Senha").HasMaxLength(100).IsRequired();
        builder.Property(u => u.DataHoraCadastro).HasColumnName("DataHoraCadastro").IsRequired();

        builder.Property(u => u.PerfilId).HasColumnName("PerfilId").IsRequired();

        //Cada usuário tem 1 perfil, cada perfil tem muitos usuários, a chave estrangeira é PerfilId
        builder.HasOne(u => u.Perfil).WithMany(u => u.Usuarios).HasForeignKey(u => u.PerfilId);




    }
}

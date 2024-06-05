using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces.Repositories;

/// <summary>
/// Contrato de métodos para o repositório de perfil
/// </summary>
public interface IPerfilRepository
{
    Perfil? GetById(Guid id);
    Perfil? GetByNome(string name);
}

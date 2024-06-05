using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces.Repositories;
public interface IUsuarioRepository
{
    void Add(Usuario usuario);
    Usuario? GetByEmail(string email);
    Usuario? GetByEmailAndPassword(string email, string senha);
    Usuario? GetById(Guid id);
}

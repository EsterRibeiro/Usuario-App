namespace UsuariosApp.API.Models;

/// <summary>
/// modelo de dados para usuário
/// </summary>
public class UsuarioMock
{
    #region Propriedades
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    #endregion


    /// <summary>
    /// Essa classe é um mexemplo de mock e não está sendo usada
    /// </summary>
    /// <returns></returns>
    #region Mock dos dados do usuário
    public static UsuarioMock MockUsuario()
    {
        return new UsuarioMock
        {
            Id = Guid.NewGuid(),
            Nome = "Usuario teste",
            Email = "usuario@teste.com.br",
            Senha = "Teste123@"
        };
    }
    #endregion
}

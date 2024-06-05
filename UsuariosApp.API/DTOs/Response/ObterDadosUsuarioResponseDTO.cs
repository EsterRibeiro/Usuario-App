namespace UsuariosApp.API.DTOs.Response;

/// <summary>
/// Objeto de dados da resposta de consulta de usuário
/// </summary>
public class ObterDadosUsuarioResponseDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public Guid PerfilId { get; set; }
    public string NomePerfil { get; set; }
}

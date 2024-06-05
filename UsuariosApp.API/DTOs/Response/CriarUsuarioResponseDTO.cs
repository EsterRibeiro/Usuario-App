namespace UsuariosApp.API.DTOs.Response;

public class CriarUsuarioResponseDTO
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public DateTime? DataHoraCadastro { get; set; }

}

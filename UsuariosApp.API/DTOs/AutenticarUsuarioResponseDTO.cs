﻿namespace UsuariosApp.API.DTOs;

/// <summary>
/// Objeto de resposta de autenticação dos usuários
/// </summary>
public class AutenticarUsuarioResponseDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public DateTime DataHoraAcesso { get; set; }
    public string AccessToken { get; set; }
    public DateTime DataHoraExpiracao { get; set; }
}

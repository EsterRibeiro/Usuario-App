using System.ComponentModel.DataAnnotations;

namespace UsuariosApp.API.DTOs.Request;

/// <summary>
/// Objeto de dados da requisição de autenticação de usuários (entrada)
/// </summary>
public class AutenticarUsuarioRequestDTO
{
    [EmailAddress(ErrorMessage ="Informe um endereço de e-mail válido")]
    [Required(ErrorMessage ="Informe o e-mail do usuário")]
    public string Email { get; set; }

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()])(?!.*\s).{8,}$",
            ErrorMessage = "Informe a senha com letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
    [Required(ErrorMessage = "Informe a senha de acesso")]
    public string Senha { get; set; }
}

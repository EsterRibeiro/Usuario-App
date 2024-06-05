using System.ComponentModel.DataAnnotations;

namespace UsuariosApp.API.DTOs.Request;


/// <summary>
/// Objeto de dados da requisição da criação de usuários
/// </summary>
public class CriarUsuarioRequestDTO
{
    [MinLength(8, ErrorMessage ="Informe no mínimo {1} caracteres")]
    [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres")]
    [Required(ErrorMessage ="Informe o nome do usuário")]
    public string? Nome { get; set; }

    [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido")]
    [Required(ErrorMessage = "Informe o e-mail do usuário")]
    public string? Email { get; set; }

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()])(?!.*\s).{8,}$",
            ErrorMessage = "Informe a senha com letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
    [Required(ErrorMessage = "Informe a senha de acesso")]
    public string? Senha { get; set; }

    [Compare("Senha", ErrorMessage ="Senhas não conferem, verifique")]
    [Required(ErrorMessage = "Confirme sua senha corretamente")]
    public string? SenhaConfirmacao { get; set; }
}

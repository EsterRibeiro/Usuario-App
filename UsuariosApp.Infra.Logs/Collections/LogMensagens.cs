namespace UsuariosApp.Infra.Logs.Collections;

/// <summary>
/// Classe de modelo de dados para as informações que serão gravadas no banco do mongoDB
/// </summary>
public class LogMensagens
{
    public Guid Id { get; set; }
    public DateTime DataHora { get; set; }
    public string? Status { get; set; }
    public string? Descricao { get; set; }
}

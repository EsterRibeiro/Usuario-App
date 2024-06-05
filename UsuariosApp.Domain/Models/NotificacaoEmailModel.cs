using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Models;

/// <summary>
/// Classe para modelagem dos dados que 
/// serão preenchidos para envio de 
/// emails de notificação
/// </summary>
public class NotificacaoEmailModel
{
    #region Propriedades
    public string EmailDestinatario { get; set; }
    public string Assunto { get; set; }
    public string? Texto { get; set; }
    #endregion
}

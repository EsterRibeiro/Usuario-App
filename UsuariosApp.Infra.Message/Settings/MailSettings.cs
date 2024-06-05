using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Message.Settings;
public class MailSettings
{
    //conta de e-mail para disparar as mensagens
    public static string Email => "sergiojavaarq@outlook.com"; //essa conta é de envio
    //senha do e-mail
    public static string Senha => "@Admin12345";

    //caminho SMTP da conta de e-mail
    public static string Smtp => "smtp-mail.outlook.com";

    //Porta para conexão com o servidor de e-mail
    public static int Porta => 587;

}

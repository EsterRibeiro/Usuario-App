using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models;
using UsuariosApp.Infra.Message.Settings;

namespace UsuariosApp.Infra.Message.Helpers;
public class MailHelper
{
    public static void Send(NotificacaoEmailModel model)
    {
        try
        {
            //construindo a mensagem
            MailMessage message = new MailMessage(MailSettings.Email, model.EmailDestinatario);
            message.Subject = model.Assunto;
            message.Body = model.Texto;
            message.IsBodyHtml = true;

            //enviando a mensagem
            var smtpClient = new SmtpClient(MailSettings.Smtp, MailSettings.Porta);
            smtpClient.Credentials = new NetworkCredential(MailSettings.Email, MailSettings.Senha);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
        }catch(Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using DotNetEnv;
using Serilog;

namespace AvaliacaoGoogle
{
    public class DisparoEmail
    {

        public void EmvioEmail()
        {
            RegistrarLogs registrarLogs = new RegistrarLogs();
            try
            {

                Env.Load(Path.Combine("../../../.env.development"));

                var user = DotNetEnv.Env.GetString("EMAIL_USER");
                var password = DotNetEnv.Env.GetString("EMAIL_PASSWORD");
                var receive = DotNetEnv.Env.GetString("EMAIL_SEND");
                var smtpPorta = DotNetEnv.Env.GetInt("SMTP_PORT");
                var smtpServer = DotNetEnv.Env.GetString("SMTP_SERVER");

                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("Sistema", user));
                email.To.Add(new MailboxAddress("Destino", receive));

                email.Subject = "Teste envio de email";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = "Houve um novo comentario no seu feeed do instagram."
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(smtpServer, smtpPorta, false);
                    smtp.Authenticate(user, password);

                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                {
                    registrarLogs.RegistrosErrosLogs(ex.Message);      
                }
            }
        }
    }
}
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace NetB.Infraestrutura
{
    public class Email
    {
        public async Task<bool> EnviarEmail()
        {
            return await Task.Run<bool>(() =>
            {
                try
                {
                    SmtpClient Smtp = new SmtpClient();
                    Smtp.EnableSsl = true;
                    Smtp.Port = 587;
                    Smtp.Host = "smtp.gmail.com";
                    Smtp.UseDefaultCredentials = false;
                    Smtp.Credentials = new NetworkCredential("tccredes4", "senhatcc");

                    MailAddress email = new MailAddress("tccredes4@gmail.com", "daniel daddato");
                    MailMessage mensagem = new MailMessage();
                    mensagem.From = new MailAddress("tccredes4@gmail.com");
                    mensagem.To.Add(email);
                    mensagem.Subject = "Teste Email netb";
                    mensagem.Body = "Teste Email netb";
                    Smtp.Send(mensagem);
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            });
        }
    }
}
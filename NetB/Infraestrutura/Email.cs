using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NetB.Infraestrutura
{
    public class Email
    {
        public async Task<bool> EnviarEmail( string responsavel, List<string> usuarios, string assunto, string Corpo)
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

                    MailAddress email = new MailAddress(responsavel);
                    MailMessage mensagem = new MailMessage();
                    mensagem.From = new MailAddress("tccredes4@gmail.com");
                    mensagem.To.Add(email);
                    usuarios.ForEach(x =>
                    {
                        mensagem.CC.Add(new MailAddress(x));
                    });
                    mensagem.Subject = assunto;
                    mensagem.Body = Corpo;
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
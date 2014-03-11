using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Harias.Smtp4DevTesting
{
    class Program
    {
        static void Main(string[] args)
        {             
            MailMessage msg = new MailMessage();

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            try
            {
                msg.Subject = "Tu asunto";
                msg.Body = "<strong>Tu contenido del email</strong>";
                msg.IsBodyHtml = true;
                msg.From = new MailAddress("TuUsuarioRemitente@dominio.com");
                msg.To.Add("TuDestinatario@dominio.com");
                msg.IsBodyHtml = true;
                client.Host = "localhost"; /* ó Ip de tu equipo ()*/
                
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("TuUsuarioRemitente@dominio.com", "TuClave");
                
                client.Port = int.Parse("25");
              
                // client.EnableSsl = true;   /*Lanza error*/

                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;          

                client.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }      

            Console.ReadLine();
        }
    }
}

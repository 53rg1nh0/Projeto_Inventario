using InventarioTI.Exceptions;
using InventarioTI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioTI.Services
{
    static class Servico
    {
        public static void EnviarEmail(string email,string senha)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("serginhoagostinho@gmail.com", "ojhjaiztpweaxqjt");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage mensagem = new MailMessage();

                mensagem.From = new MailAddress("serginhoagostinho@gmail.com", "INVENTÁRIO TI (Código para auteração de senha)");
                mensagem.To.Add(new MailAddress("serginhoagostinho@gmail.com"));

                mensagem.Subject = "Alterar senha Sistema Inventário TI";
                mensagem.Body = "Para verifiar sua identidade, use o código: \n" + senha;

                mensagem.IsBodyHtml = true;

                client.Send(mensagem);

            }
            catch
            {
                throw new DomainException("Verifique se e-mail está correto!");
            }
        }
        public static string GerarCodigo()
        {
            string chars = @"abcdefghjkmnpqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVYWXZ023456789!@#$%¨&*";
            string pass = "";
            Random random = new Random();
            for (int f = 0; f < 8; f++)
            {
                pass = pass + chars.Substring(random.Next(0, chars.Length - 1), 1);
            }
            return pass;
        }

       
    }
}

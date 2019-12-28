using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BLL
{
    public class Correo
    {
        public void EnviarCorreo(string EmailDestino, string mensaje)
        {
            string EmailOrigen = "ontour.concepcion@gmail.com";
            string Contraseña = "Ontour2019";

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Pago de cuota", mensaje);

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpClient.Send(oMailMessage);

            oSmtpClient.Dispose();
        }
    }

    
}
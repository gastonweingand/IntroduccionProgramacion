using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RepasoClase4.DomainModel.Academia
{
    public class EmailSender
    {
        public void Send(string from, string to, string subject, string body)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com.", 465);

            //Buscar para agregar las credenciales
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("username", "password");

            smtpClient.Send(from, to, subject, body);

        }
    }
}

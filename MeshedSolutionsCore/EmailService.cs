using System.Net;
using System.Net.Mail;

namespace MeshedSolutionsCore
{
    public class EmailService
    {
        private SmtpClient _smtpClient;
        private readonly string _smtpServer = string.Empty;
        private readonly int _smtpPort;
        private readonly string _userName = string.Empty;
        private readonly string _password = string.Empty;

        public EmailService(string smtpServer, int smtpPort, string userName, string password)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _userName = userName;
            _password = password;
        }

        public void SendEmail(string from, string to, string subject, string body)
        {
            var mailMessage = new MailMessage(from, to, subject, body);

            Send(mailMessage);
        }

        private void Send(MailMessage mailMessage)
        {
            _smtpClient = _smtpPort == 0 ? new SmtpClient(_smtpServer) : new SmtpClient(_smtpServer, _smtpPort);
            _smtpClient.Credentials = new NetworkCredential(_userName, _password);

            if (mailMessage != null) _smtpClient.Send(mailMessage);
        }
    }
}

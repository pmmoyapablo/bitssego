using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Sisgtfhka.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private String ServerHost;
        private int Port;
        private bool EnableSsl;
        private String EmailFrom;
        private String PasswordEmail;
        public void LoadConfigurations(AppSettings appSettings)
        {
            this.ServerHost = appSettings.Server_Mail;
            this.Port = appSettings.Port_Mail;
            this.EnableSsl = appSettings.EnableSsl;
            this.EmailFrom = appSettings.Email_From;
            this.PasswordEmail = appSettings.Password_Email;
        }

        public Task SendEmailAsync(string email, string subject, string text)
        {
            try
            {
                MailAddress from = new MailAddress(EmailFrom, "[SGO-TFHKA]", System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress(email);
                MailMessage message = new MailMessage(from, to);
                string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string scriptFile = appPath + "\\ScriptHtmlMail.html";
                message.Subject = subject;
                string htmlString = File.ReadAllText(scriptFile);
                message.IsBodyHtml = true;
                message.Body = htmlString.Replace("{text}", text);
                message.Priority = MailPriority.Normal;
                SmtpClient server = new SmtpClient();
                server.Host = this.ServerHost;
                server.Port = this.Port;
                server.EnableSsl = this.EnableSsl;
                server.DeliveryMethod = SmtpDeliveryMethod.Network;
                server.UseDefaultCredentials = false;
                server.Credentials = new System.Net.NetworkCredential(EmailFrom, this.PasswordEmail);
                server.Send(message);
                
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}

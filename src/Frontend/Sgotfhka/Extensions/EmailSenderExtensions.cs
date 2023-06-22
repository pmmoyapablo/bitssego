using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Sisgtfhka.Services;

namespace Sisgtfhka.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirme su email",
                $"Por favor confirme su cuenta haciendo click en este enlace: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Services
{
    public interface IEmailSender
    {
        void LoadConfigurations(AppSettings appSettings);
        Task SendEmailAsync(string email, string subject, string message);
    }
}

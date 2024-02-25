using SOLID.Principles.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Principles
{
    public class UserService
    {
        EmailService _emailService;
        DbContext _dbContext;
        public UserService(EmailService aEmailService, DbContext aDbContext)
        {
            _emailService = aEmailService;
            _dbContext = aDbContext;
        }

        public void Register(string email, string password, DbContext _dbContext)
        {
            if (!_emailService.ValidateEmail(email))
                throw new ValidationException("Email is not an email");
            var user = new User(email, password);
            var isSaved = _dbContext.Save(user);
            if(isSaved)
              _emailService.SendEmail(new MailMessage("myname@mydomain.com", email) { Subject = "Updated details sucessfully" });
        }
    }
    public class EmailService
    {
        SmtpClient _smtpClient;
        public EmailService(SmtpClient aSmtpClient)
        {
            _smtpClient = aSmtpClient;
        }
        public virtual bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }
        public void SendEmail(MailMessage message)
        {
            _smtpClient.Send(message);
        }
    }
}

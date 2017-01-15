using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Web.Mail;
using System.Web.UI.WebControls;
using System.IO;

namespace Assassins.Controllers
{
    public class EmailUtil
    {
        private string smtpServer;
        private string smtpUserName;
        private string smtpPassword;

        public EmailUtil()
        {
            this.smtpServer = "smtp.sendgrid.net";
            this.smtpUserName = "#######";
            this.smtpPassword = "#######";
        }

        public bool SendEmail(string fromEmailAddress, string toEmailAddress, string subject, string body, bool isHtml, ListDictionary replacements)
        {
            var md = new MailDefinition
            {
                From = fromEmailAddress,
                IsBodyHtml = isHtml,
                Subject = subject
            };

            System.Net.Mail.MailMessage mail = md.CreateMailMessage(toEmailAddress, replacements, body, new System.Web.UI.Control());

            try
            {
                SmtpClient smtpClient = new SmtpClient(smtpServer);
                if (!string.IsNullOrEmpty(smtpUserName) && !string.IsNullOrEmpty(smtpPassword))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
                }
                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        public bool send(string fromEmailAddress, string toEmailAddress, string subject, string body, bool isHtml, ListDictionary replacements, AlternateView alt)
        {
            var md = new MailDefinition
            {
                From = fromEmailAddress,
                IsBodyHtml = isHtml,
                Subject = subject
            };

            System.Net.Mail.MailMessage mail = md.CreateMailMessage(toEmailAddress, replacements, body, new System.Web.UI.Control());
            mail.AlternateViews.Add(alt);
            try
            {
                SmtpClient smtpClient = new SmtpClient(smtpServer);
                if (!string.IsNullOrEmpty(smtpUserName) && !string.IsNullOrEmpty(smtpPassword))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
                }
                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }
    }
}

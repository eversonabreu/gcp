using Microsoft.Extensions.Configuration;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;
        private string title;
        private List<string> recipients;
        private List<string> recipientsCopy;
        private List<string> recipientsCopyHidden;
        private string body;
        private bool isBodyHtml;
        private List<(MemoryStream, string, string)> attachments;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
            attachments = new List<(MemoryStream, string, string)>();
        }

        public IEmailService WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public IEmailService WithRecipient(string recipient)
        {
            recipients = new List<string> { recipient };
            return this;
        }

        public IEmailService WithRecipients(IList<string> recipients)
        {
            this.recipients = new List<string>();
            this.recipients.AddRange(recipients);
            return this;
        }

        public IEmailService WithRecipientCopy(string recipientCopy)
        {
            recipientsCopy = new List<string> { recipientCopy };
            return this;
        }

        public IEmailService WithRecipientsCopy(IList<string> recipientsCopy)
        {
            this.recipientsCopy = new List<string>();
            this.recipientsCopy.AddRange(recipientsCopy);
            return this;
        }

        public IEmailService WithRecipientCopyHidden(string recipientCopyHidden)
        {
            recipientsCopyHidden = new List<string> { recipientCopyHidden };
            return this;
        }

        public IEmailService WithRecipientsCopyHidden(IList<string> recipientsCopyHidden)
        {
            this.recipientsCopyHidden = new List<string>();
            this.recipientsCopyHidden.AddRange(recipientsCopyHidden);
            return this;
        }

        public IEmailService WithBody(string body, bool isBodyHtml = false)
        {
            this.body = body;
            this.isBodyHtml = isBodyHtml;
            return this;
        }

        public IEmailService AddAttachment(byte[] memoryFile, string nameAttachment, string cid = null)
        {
            attachments.Add((new MemoryStream(memoryFile), nameAttachment, cid));
            return this;
        }

        public IEmailService RemoveAllAttachments()
        {
            attachments = new List<(MemoryStream, string, string)>();
            return this;
        }

        public bool Send()
        {
            bool result = false;

            try
            {
                var (smtpClient, mailMessage) = GetSmtpClientAndMailMessage();
                smtpClient.Send(mailMessage);
                result = true;
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Erro ao enviar e-mail: '{exc.Message}'.");
            }

            ClearFields();
            return result;
        }

        public async Task<bool> SendAsync()
        {
            bool result = false;

            try
            {
                var (smtpClient, mailMessage) = GetSmtpClientAndMailMessage();
                await smtpClient.SendMailAsync(mailMessage);
                result = true;
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Erro ao enviar e-mail assíncrono: '{exc.Message}'.");
            }

            ClearFields();
            return result;
        }

        private (SmtpClient smtpClient, MailMessage mailMessage) GetSmtpClientAndMailMessage()
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Title is not defined in e-mail");
            }

            if (string.IsNullOrWhiteSpace(body))
            {
                throw new ArgumentNullException("Body is not defined in e-mail");
            }

            if (recipients == null || recipients.Count == 0)
            {
                throw new ArgumentNullException("Recipients is not defined in e-mail");
            }

            var section = configuration.GetSection("EmailSettings");
            var mailMessage = new MailMessage
            {
                From = new MailAddress(section.GetSection("From").Value),
                Subject = title,
                Body = body,
                IsBodyHtml = isBodyHtml
            };

            foreach (string to in recipients)
            {
                mailMessage.To.Add(to);
            }

            if (recipientsCopy != null)
            {
                foreach (string cc in recipientsCopy)
                {
                    mailMessage.CC.Add(cc);
                }
            }

            if (recipientsCopyHidden != null)
            {
                foreach (string bcc in recipientsCopyHidden)
                {
                    mailMessage.Bcc.Add(bcc);
                }
            }

            foreach (var item in attachments)
            {
                var ath = new Attachment(item.Item1, item.Item2);
                if (item.Item3 != null)
                {
                    ath.ContentDisposition.Inline = true;
                    ath.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    ath.ContentId = item.Item3;
                    ath.ContentType.MediaType = "image/png";
                    ath.ContentType.Name = "png";
                }

                mailMessage.Attachments.Add(ath);
            }

            var smtpClient = new SmtpClient(section.GetSection("Host").Value)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = bool.Parse(section.GetSection("EnableSsl").Value),
                UseDefaultCredentials = bool.Parse(section.GetSection("UseDefaultCredentials").Value),
                Credentials = new NetworkCredential(section.GetSection("User").Value, section.GetSection("Password").Value),
                Port = int.Parse(section.GetSection("Port").Value)
            };

            return (smtpClient, mailMessage);
        }

        private void ClearFields()
        {
            attachments = new List<(MemoryStream, string, string)>();
            title = null;
            body = null;
            isBodyHtml = false;
            recipients = null;
            recipientsCopy = null;
            recipientsCopyHidden = null;
        }
    }
}
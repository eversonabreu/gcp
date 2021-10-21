using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IEmailService
    {
        IEmailService WithTitle(string title);

        IEmailService WithRecipient(string recipient);

        IEmailService WithRecipients(IList<string> recipients);

        IEmailService WithRecipientCopy(string recipientCopy);

        IEmailService WithRecipientsCopy(IList<string> recipientsCopy);

        IEmailService WithRecipientCopyHidden(string recipientCopyHidden);

        IEmailService WithRecipientsCopyHidden(IList<string> recipientsCopyHidden);

        IEmailService WithBody(string body, bool isBodyHtml = false);

        IEmailService AddAttachment(byte[] memoryFile, string nameAttachment, string cid = null);

        IEmailService RemoveAllAttachments();

        bool Send();

        Task<bool> SendAsync();
    }
}

namespace Senac.GCP.Domain.Exceptions
{
    public sealed class SendEmailException : BusinessException
    {
        public SendEmailException(string message) : base(message) { }
    }
}

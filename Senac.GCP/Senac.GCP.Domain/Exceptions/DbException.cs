namespace Senac.GCP.Domain.Exceptions
{
    public sealed class DbException : BusinessException
    {
        public DbException(string message) : base(message) { }
    }
}

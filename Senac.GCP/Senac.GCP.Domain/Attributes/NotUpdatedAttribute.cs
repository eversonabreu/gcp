using System;

namespace Senac.GCP.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NotUpdatedAttribute : Attribute
    {
    }
}

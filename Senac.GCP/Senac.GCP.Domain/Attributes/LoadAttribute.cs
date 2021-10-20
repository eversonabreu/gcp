using System;

namespace Senac.GCP.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class LoadEntityAttribute : Attribute
    {
        public string NameForeignKey { get; set; }
    }
}

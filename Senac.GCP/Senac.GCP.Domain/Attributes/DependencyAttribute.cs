using System;

namespace Senac.GCP.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DependencyAttribute : Attribute
    {
        public string NameForeignKey { get; set; }
    }
}

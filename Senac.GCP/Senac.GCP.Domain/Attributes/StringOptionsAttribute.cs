using Senac.GCP.Domain.Enums;
using System;

namespace Senac.GCP.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class StringOptionsAttribute : Attribute
    {
        public TrimSpaceEnum TrimSpace { get; set; } = TrimSpaceEnum.None;

        public AlterCaseEnum AlterCase { get; set; } = AlterCaseEnum.None;
    }
}
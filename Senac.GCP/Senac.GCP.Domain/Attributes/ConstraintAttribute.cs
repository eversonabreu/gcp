using System;

namespace Senac.GCP.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ConstraintAttribute : Attribute
    {
        public string Name { get; set; }

        public string ErrorMessage { get; set; }
    }
}

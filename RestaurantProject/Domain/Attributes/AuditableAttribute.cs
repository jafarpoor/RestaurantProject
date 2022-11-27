using System;

namespace Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuditableAttribute :Attribute
    {
    }
}

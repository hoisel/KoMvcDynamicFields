using System;

namespace KoMvcRepeatingFieldGroup.Common.Attributes
{
    [AttributeUsage( AttributeTargets.Property, Inherited = true, AllowMultiple = false )]
    public sealed class ExpandAttribute : Attribute
    { }
}
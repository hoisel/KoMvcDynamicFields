using System;

namespace KoMvcDynamicFields.Common.Attributes
{
    // Marker attribute
    [System.AttributeUsage( System.AttributeTargets.Property, AllowMultiple = false,Inherited = true )]
    public class DynamicAttribute : System.Attribute { }
}
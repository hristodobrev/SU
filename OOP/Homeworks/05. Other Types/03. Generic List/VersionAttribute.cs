namespace _03.Generic_List
{
    using System;
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(string version)
        {
            this.Version = version;
        }

        public string Version { get; set; }
    }
}

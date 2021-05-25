using System;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class LocalizedDisplayAttribute : Attribute
    {
        public LocalizedDisplayAttribute()
        {
        }

        public string DisplayName
        {
            get
            {
                return DisplayName;
            }
            set
            {

            }
        }
    }
}

using SampleProject.Model.Authorize;

namespace SampleProject.Core.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class HasPermissionAttribute : Attribute
    {
        public HasPermissionAttribute()
        {

        }
    }
}

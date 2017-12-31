using System;
namespace ServiceUtilities
{
    public interface IUtilitySelector
    {
        void Select(string[] args, AccessibleServiceBase service, IConfiguration configuration, string assemblyFullName);
    }
}

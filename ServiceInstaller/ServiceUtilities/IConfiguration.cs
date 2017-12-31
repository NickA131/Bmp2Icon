using System;
namespace ServiceUtilities
{
    public interface IConfiguration
    {
        string ServiceDisplayName { get; }
        string ServiceName { get; }
        string ServiceDescription { get; }
    }
}

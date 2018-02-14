using System;

namespace SvcFabricDinnerDemo.ReliableServicesCore
{
    public interface IServiceFabricUriBuilder
    {
        Uri Build(string servicename);
    }
}
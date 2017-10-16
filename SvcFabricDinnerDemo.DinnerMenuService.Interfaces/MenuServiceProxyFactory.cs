using System;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace SvcFabricDinnerDemo.DinnerMenuService.Interfaces
{
    public class MenuServiceProxyFactory
    {
        public static Uri Servicename { get; } = new Uri("fabric:/SvcFabricDinnerDemo/DinnerMenuService");

        public IDinnerMenuService CreateServiceProxy(Guid restaurantId)
        {
            var key = Hashcalculator.Calculate(restaurantId);
            return ServiceProxy.Create<IDinnerMenuService>(Servicename, key);
        }

        public IDinnerMenuAdminService CreateAdminServiceProxy(Guid restaurantId)
        {
            var key = Hashcalculator.Calculate(restaurantId);
            return ServiceProxy.Create<IDinnerMenuAdminService>(Servicename, key);
        }

        public IDinnerMenuAdminService CreateAdminServiceProxy(ServicePartitionKey key)
        {
            return ServiceProxy.Create<IDinnerMenuAdminService>(Servicename, key);
        }
    }
}
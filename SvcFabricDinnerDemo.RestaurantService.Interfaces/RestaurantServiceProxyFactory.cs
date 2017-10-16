using System;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace SvcFabricDinnerDemo.RestaurantService.Interfaces
{
    public class RestaurantServiceProxyFactory
    {
        private static readonly Uri _servicename = new Uri("fabric:/SvcFabricDinnerDemo/RestaurantService");
        
        public RestaurantServiceProxyFactory()
        { }

        public static Uri Servicename => _servicename;

        public IRestaurantService CreateServiceProxy()
        {
            return ServiceProxy.Create<IRestaurantService>(_servicename, new ServicePartitionKey(0));
        }
        public IRestaurantAdminService CreateAdminServiceProxy()
        {
            return ServiceProxy.Create<IRestaurantAdminService>(_servicename, new ServicePartitionKey(0));
        }
    }
}
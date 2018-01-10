using System;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SvcFabricDinnerDemo.ReliableServicesCore;

namespace SvcFabricDinnerDemo.RestaurantService.Interfaces
{
    public class RestaurantServiceProxyFactory
    {
        private static readonly string _localservicename = "RestaurantService";
        private readonly Uri _servicename;

        public RestaurantServiceProxyFactory() : this(new ServiceFabricUriBuilder()) {}

        public RestaurantServiceProxyFactory(IServiceFabricUriBuilder serviceFabricUriBuilder)
        {
            this._servicename = serviceFabricUriBuilder.Build(_localservicename);
        }

        public Uri Servicename => _servicename;

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
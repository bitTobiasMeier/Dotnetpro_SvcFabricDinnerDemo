using System;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SvcFabricDinnerDemo.ReliableServicesCore;

namespace SvcFabricDinnerDemo.DinnerMenuService.Interfaces
{


    public class MenuServiceProxyFactory
    {
        private static readonly string _localservicename = "DinnerMenuService";
        private readonly Uri _servicename;

        public MenuServiceProxyFactory() : this(new ServiceFabricUriBuilder()) { }

        public MenuServiceProxyFactory(IServiceFabricUriBuilder serviceFabricUriBuilder)
        {
            this._servicename = serviceFabricUriBuilder.Build(_localservicename);
        }

        public Uri Servicename
        {
            get { return _servicename; }
        }


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
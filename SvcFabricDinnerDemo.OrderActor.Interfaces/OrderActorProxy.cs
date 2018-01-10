using System;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using SvcFabricDinnerDemo.ReliableServicesCore;

namespace SvcFabricDinnerDemo.OrderActor.Interfaces
{
    public class OrderActorProxy
    {
        private readonly string InternalServiceName = "OrderActorService";
        private readonly Uri _serviceUrl;

        public OrderActorProxy() : this (new ServiceFabricUriBuilder()) { }
        public OrderActorProxy(IServiceFabricUriBuilder serviceFabricUriBuilder)
        {
            this._serviceUrl = serviceFabricUriBuilder.Build(this.InternalServiceName);
        }

        public Uri ServiceUrl
        {
            get { return this._serviceUrl; }
        }

        public IOrderActor CreateActor(Guid orderId)
        {
            var actorId = new ActorId(orderId);
            return ActorProxy.Create<IOrderActor>(actorId, ServiceUrl);
        }
    }
}
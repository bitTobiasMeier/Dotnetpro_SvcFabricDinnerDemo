using System;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using SvcFabricDinnerDemo.ReliableServicesCore;

namespace SvcFabricDinnerDemo.KitchenActor.Interfaces
{
    public class KitchenActorProxy
    {
        private readonly string InternalServiceName = "KitchenActorService";
        private readonly Uri _serviceUrl;

        public KitchenActorProxy() : this (new ServiceFabricUriBuilder()) { }
        public KitchenActorProxy(IServiceFabricUriBuilder serviceFabricUriBuilder)
        {
            this._serviceUrl = serviceFabricUriBuilder.Build(this.InternalServiceName);
        }

        public Uri ServiceUrl
        {
            get { return this._serviceUrl; }
        }


        public IKitchenActor CreateActor(Guid orderId)
        {
            var actorId = new ActorId(orderId);
            return ActorProxy.Create<IKitchenActor>(actorId, ServiceUrl);
        }
    }
}
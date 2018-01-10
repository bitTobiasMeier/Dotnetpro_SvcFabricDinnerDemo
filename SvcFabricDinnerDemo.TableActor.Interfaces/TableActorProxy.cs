using System;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using SvcFabricDinnerDemo.ReliableServicesCore;

namespace SvcFabricDinnerDemo.TableActor.Interfaces
{
    public class TableActorProxy
    {
        private readonly string InternalServiceName = "TableActorService";
        private readonly Uri _serviceUrl;

        public TableActorProxy() : this (new ServiceFabricUriBuilder()) { }
        public TableActorProxy(IServiceFabricUriBuilder serviceFabricUriBuilder)
        {
            this._serviceUrl = serviceFabricUriBuilder.Build(this.InternalServiceName);
        }

        public Uri ServiceUrl
        {
            get { return this._serviceUrl; }
        }


        public ITableActor CreateActor(Guid tableId)
        {
            var actorId = new ActorId(tableId);
            return ActorProxy.Create<ITableActor>(actorId, ServiceUrl);
        }

    }

    public interface ITableActorService : IBackupRestoreActorService
    {

    }


}
using System;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using SvcFabricDinnerDemo.ReliableServicesCore;

namespace SvcFabricDinnerDemo.TableActor.Interfaces
{
    public class TableActorProxy
    {
        public static Uri ServiceUrl { get; } = new Uri("fabric:/SvcFabricDinnerDemo/TableActorService");


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
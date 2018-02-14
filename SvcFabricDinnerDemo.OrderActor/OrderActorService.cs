using System;
using System.Fabric;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using SvcFabricDinnerDemo.OrderActor.Interfaces;
using SvcFabricDinnerDemo.ReliableServicesCore;

namespace SvcFabricDinnerDemo.OrderActor
{
    public class OrderActorService : BackupRestoreActorService, IOrderActorService
    {
        public OrderActorService(StatefulServiceContext context, ActorTypeInformation actorTypeInfo, IFileStore fileStore,
            IServiceEventSource serviceEventSource, Func<ActorService, ActorId, ActorBase> actorFactory = null,
            Func<ActorBase, IActorStateProvider, IActorStateManager> stateManagerFactory = null, IActorStateProvider stateProvider = null,
            ActorServiceSettings settings = null) : base(context, actorTypeInfo, fileStore, serviceEventSource, actorFactory, stateManagerFactory, stateProvider, settings)
        {
        }
    }
}
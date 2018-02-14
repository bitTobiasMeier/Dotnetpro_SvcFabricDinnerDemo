using System;
using System.Fabric;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using SvcFabricDinnerDemo.ReliableServicesCore;
using SvcFabricDinnerDemo.TableActor.Interfaces;

namespace SvcFabricDinnerDemo.TableActor
{
    public class TableActorService : BackupRestoreActorService, ITableActorService
    {
        public TableActorService(StatefulServiceContext context, ActorTypeInformation actorTypeInfo, IFileStore fileStore, 
            IServiceEventSource serviceEventSource, Func<ActorService, ActorId, ActorBase> actorFactory = null, 
            Func<ActorBase, IActorStateProvider, IActorStateManager> stateManagerFactory = null, IActorStateProvider stateProvider = null, 
            ActorServiceSettings settings = null) : base(context, actorTypeInfo, fileStore, serviceEventSource, actorFactory, stateManagerFactory, stateProvider, settings)
        {
        }
    }
}
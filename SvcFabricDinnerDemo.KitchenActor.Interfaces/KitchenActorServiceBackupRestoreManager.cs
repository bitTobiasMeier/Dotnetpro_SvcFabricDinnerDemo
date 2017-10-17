﻿using System;
using System.Fabric;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors.Client;

namespace SvcFabricDinnerDemo.KitchenActor.Interfaces
{
 

    public class KitchenActorServiceBackupRestoreManager : IKitchenActorServiceBackupRestoreManager
    {

        public async Task TakeFullBackupAsync(string nameOfBackupset)
        {            
            using (var client = new FabricClient())
            {
                var partitions = await client.QueryManager.GetPartitionListAsync(KitchenActorProxy.ServiceUrl);
                foreach (var partition in partitions)
                {
                    if (partition.PartitionInformation.Kind != ServicePartitionKind.Int64Range)
                    {
                        throw new Exception("Unexpected Partition Kind");
                    }

                    if (!(partition.PartitionInformation is Int64RangePartitionInformation actorpartition)) throw new Exception("Unexpected partition type");

                    
                    var actorServiceProxy = ActorServiceProxy.Create<IKitchenActorService>(KitchenActorProxy.ServiceUrl, actorpartition.LowKey);
                    await actorServiceProxy.BackupActorsAsync(nameOfBackupset);
                }
            }
        }

        public async Task RestoreFullBackupAsync(string nameOfBackupset)
        {
            using (var client = new FabricClient())
            {
                var partitions = await client.QueryManager.GetPartitionListAsync(KitchenActorProxy.ServiceUrl);
                foreach (var partition in partitions)
                {
                    if (partition.PartitionInformation.Kind != ServicePartitionKind.Int64Range)
                    {
                        throw new Exception("Unexpected Partition Kind");
                    }

                    if (!(partition.PartitionInformation is Int64RangePartitionInformation actorpartition)) throw new Exception("Unexpected partition type");
         
                    var actorServiceProxy = ActorServiceProxy.Create<IKitchenActorService>(KitchenActorProxy.ServiceUrl, actorpartition.LowKey);
                    await actorServiceProxy.RestoreActorsAsync(nameOfBackupset);
                }
            }
        }
    }
}
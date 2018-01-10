using System;
using System.Fabric;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors.Client;

namespace SvcFabricDinnerDemo.OrderActor.Interfaces
{
    public class OrderActorServiceBackupRestoreManager : IOrderActorServiceBackupRestoreManager
    {

        public async Task TakeFullBackupAsync(string nameOfBackupset)
        {
            using (var client = new FabricClient())
            {
                var serviceUrl = new OrderActorProxy().ServiceUrl;
                var partitions = await client.QueryManager.GetPartitionListAsync(serviceUrl);
                foreach (var partition in partitions)
                {
                    if (partition.PartitionInformation.Kind != ServicePartitionKind.Int64Range)
                    {
                        throw new Exception("Unexpected Partition Kind");
                    }

                    if (!(partition.PartitionInformation is Int64RangePartitionInformation actorpartition)) throw new Exception("Unexpected partition type");


                    var actorServiceProxy = ActorServiceProxy.Create<IOrderActorService>(serviceUrl, actorpartition.LowKey);
                    await actorServiceProxy.BackupActorsAsync(nameOfBackupset);
                }
            }
        }

        public async Task RestoreFullBackupAsync(string nameOfBackupset)
        {
            using (var client = new FabricClient())
            {
                var serviceUrl = new OrderActorProxy().ServiceUrl;
                var partitions = await client.QueryManager.GetPartitionListAsync(serviceUrl);
                foreach (var partition in partitions)
                {
                    if (partition.PartitionInformation.Kind != ServicePartitionKind.Int64Range)
                    {
                        throw new Exception("Unexpected Partition Kind");
                    }

                    if (!(partition.PartitionInformation is Int64RangePartitionInformation actorpartition)) throw new Exception("Unexpected partition type");

                    var actorServiceProxy = ActorServiceProxy.Create<IOrderActorService>(serviceUrl, actorpartition.LowKey);
                    await actorServiceProxy.RestoreActorsAsync(nameOfBackupset);
                }
            }
        }
    }
}
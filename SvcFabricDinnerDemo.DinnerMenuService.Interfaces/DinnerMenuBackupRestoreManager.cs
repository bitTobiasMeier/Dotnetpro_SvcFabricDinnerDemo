using System.Fabric;
using System.Threading.Tasks;

namespace SvcFabricDinnerDemo.DinnerMenuService.Interfaces
{
    public interface IDinnerMenuBackupRestoreManager
    {
        Task TakeFullBackUpAsync(string nameOfBackupset);
        Task RestoreFullBackUpAsync(string nameOfBackupset);
    }

    public class DinnerMenuBackupRestoreManager : IDinnerMenuBackupRestoreManager
    {
        public async Task TakeFullBackUpAsync(string nameOfBackupset)
        {
            var proxyFactory = new MenuServiceProxyFactory();
            using (var client = new FabricClient())
            {
                var partitions = await client.QueryManager.GetPartitionListAsync(MenuServiceProxyFactory.Servicename);
                foreach (var partition in partitions)
                {
                   
                    var proxy = proxyFactory.CreateAdminServiceProxy(partition.PartitionInformation.Id);
                    await proxy.BackupServiceAsync(nameOfBackupset);
                }
            }

        }

        public async Task RestoreFullBackUpAsync(string nameOfBackupset)
        {
            var proxyFactory = new MenuServiceProxyFactory();
            using (var client = new FabricClient())
            {
                var partitions = await client.QueryManager.GetPartitionListAsync(MenuServiceProxyFactory.Servicename);
                foreach (var partition in partitions)
                {

                    var proxy = proxyFactory.CreateAdminServiceProxy(partition.PartitionInformation.Id);
                    await proxy.RestoreServiceAsync(nameOfBackupset);
                }
            }
        }
    }
}
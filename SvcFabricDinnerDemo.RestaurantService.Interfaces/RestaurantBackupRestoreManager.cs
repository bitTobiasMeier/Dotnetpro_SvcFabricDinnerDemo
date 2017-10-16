using System.Threading.Tasks;

namespace SvcFabricDinnerDemo.RestaurantService.Interfaces
{
    public class RestaurantBackupRestoreManager : IRestaurantBackupRestoreManager
    {
        public async Task TakeFullBackUpAsync(string nameOfBackupset)
        {
            var proxy = new RestaurantServiceProxyFactory().CreateAdminServiceProxy();
            await proxy.BackupServiceAsync(nameOfBackupset);
            
        }

        public async Task RestoreFullBackUpAsync(string nameOfBackupset)
        {
            var proxy = new RestaurantServiceProxyFactory().CreateAdminServiceProxy();
            await proxy.RestoreServiceAsync(nameOfBackupset);
        }
    }
}
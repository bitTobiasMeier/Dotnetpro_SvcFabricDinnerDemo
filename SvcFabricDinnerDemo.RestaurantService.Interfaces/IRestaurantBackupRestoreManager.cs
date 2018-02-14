using System.Threading.Tasks;

namespace SvcFabricDinnerDemo.RestaurantService.Interfaces
{
    public interface IRestaurantBackupRestoreManager
    {
        Task TakeFullBackUpAsync(string nameOfBackupset);
        Task RestoreFullBackupAsync(string nameOfBackupset);
    }
}
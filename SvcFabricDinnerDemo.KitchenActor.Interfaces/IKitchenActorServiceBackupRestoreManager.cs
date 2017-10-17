using System.Threading.Tasks;

namespace SvcFabricDinnerDemo.KitchenActor.Interfaces
{
    public interface IKitchenActorServiceBackupRestoreManager
    {
        Task TakeFullBackupAsync(string nameOfBackupset);
        Task RestoreFullBackupAsync(string nameOfBackupset);
    }
}
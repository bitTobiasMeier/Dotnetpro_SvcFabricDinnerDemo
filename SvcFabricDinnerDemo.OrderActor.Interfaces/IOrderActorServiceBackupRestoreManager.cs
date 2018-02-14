using System.Threading.Tasks;

namespace SvcFabricDinnerDemo.OrderActor.Interfaces
{
    public interface IOrderActorServiceBackupRestoreManager
    {
        Task TakeFullBackupAsync(string nameOfBackupset);
        Task RestoreFullBackupAsync(string nameOfBackupset);
    }
}
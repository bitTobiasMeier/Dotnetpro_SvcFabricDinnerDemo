using System.Threading.Tasks;

namespace SvcFabricDinnerDemo.TableActor.Interfaces
{
    public interface ITableActorServiceBackupRestoreManager
    {
        Task TakeFullBackupAsync(string nameOfBackupset);
        Task RestoreFullBackupAsync(string nameOfBackupset);
    }
}
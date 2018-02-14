using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace SvcFabricDinnerDemo.ReliableServicesCore
{
    public interface IBackupRestoreActorService : IService
    {
        Task BackupActorsAsync(string nameofbackupset);
        Task RestoreActorsAsync(string nameOfBackupSet);
    }
}
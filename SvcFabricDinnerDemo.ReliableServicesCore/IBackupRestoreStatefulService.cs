using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace SvcFabricDinnerDemo.ReliableServicesCore
{
    public interface IBackupRestoreStatefulService: IService
    {
        Task BackupServiceAsync(string nameofbackupset);
        Task RestoreServiceAsync(string nameOfBackupSet);
    }
}
using System.Fabric;

namespace SvcFabricDinnerDemo.ReliableServicesCore
{
    public class AzureBackupRestoreConfiguration
    {
        private readonly string _backupStorageConnectionString ;
        public AzureBackupRestoreConfiguration(StatefulServiceContext context)
        {
            this._backupStorageConnectionString = context.GetBackupStorageConnectionString();
            
        }

        public string BackupStorageConnectionString
        {
            get { return _backupStorageConnectionString; }
        }
    }
}
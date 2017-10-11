using System.Fabric;

namespace SvcFabricDinnerDemo.ReliableServicesCore
{
    public interface IFileStoreCreator
    {
        IFileStore CreateFileStore(StatefulServiceContext context);
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;
using SvcFabricDinnerDemo.ReliableServicesCore;

namespace SvcFabricDinnerDemo.DinnerMenuService.Interfaces
{
    public interface IDinnerMenuAdminService : IService, IBackupRestoreStatefulService
    {
        Task<Guid> AddDishAsync(Guid restaurantId, Dish dish);
    }
}
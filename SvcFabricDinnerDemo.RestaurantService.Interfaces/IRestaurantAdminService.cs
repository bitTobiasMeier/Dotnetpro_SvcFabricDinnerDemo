using System;
using System.Fabric;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;
using SvcFabricDinnerDemo.ReliableServicesCore;

namespace SvcFabricDinnerDemo.RestaurantService.Interfaces
{
    public interface IRestaurantAdminService : IService, IBackupRestoreStatefulService
    {
        Task<Restaurant> CreateRestaurant(Restaurant restaurant);
        Task<RestaurantTable> CreateTable(Guid restaurantId, RestaurantTable table);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SvcFabricDinnerDemo.DinnerMenuService.Interfaces;
using SvcFabricDinnerDemo.KitchenActor.Interfaces;
using SvcFabricDinnerDemo.OrderActor.Interfaces;
using SvcFabricDinnerDemo.RestaurantService.Interfaces;
using SvcFabricDinnerDemo.TableActor.Interfaces;

namespace SvcFabricDinnerDemo.AdminPlatform.Controllers
{
    [Route("api/[controller]")]
    public class BackupController : Controller
    {
        private readonly IRestaurantBackupRestoreManager _restaurantBackupRestoreManager;
        private readonly IDinnerMenuBackupRestoreManager _dinnerMenuBackupRestoreManager;
        private readonly IOrderActorServiceBackupRestoreManager _orderActorServiceBackupRestoreManager;
        private readonly IKitchenActorServiceBackupRestoreManager _kitchenActorServiceBackupRestoreManager;
        private readonly ITableActorServiceBackupRestoreManager _tableActorServiceBackupRestoreManager;

        public  BackupController (IRestaurantBackupRestoreManager restaurantBackupRestoreManager,
            IDinnerMenuBackupRestoreManager dinnerMenuBackupRestoreManager, 
            IOrderActorServiceBackupRestoreManager orderActorServiceBackupRestoreManager,
            IKitchenActorServiceBackupRestoreManager kitchenActorServiceBackupRestoreManager, ITableActorServiceBackupRestoreManager tableActorServiceBackupRestoreManager)
        {
            _restaurantBackupRestoreManager = restaurantBackupRestoreManager;
            _dinnerMenuBackupRestoreManager = dinnerMenuBackupRestoreManager;
            _orderActorServiceBackupRestoreManager = orderActorServiceBackupRestoreManager;
            _kitchenActorServiceBackupRestoreManager = kitchenActorServiceBackupRestoreManager;
            _tableActorServiceBackupRestoreManager = tableActorServiceBackupRestoreManager;
        }

        // GET api/values/5
        [HttpPost]
        public async Task<string> Post(string nameOfBackupSet)
        {
            var menuSvcTask = this._dinnerMenuBackupRestoreManager.TakeFullBackUpAsync(nameOfBackupSet);
            var restaurantSvcTask = this._restaurantBackupRestoreManager.TakeFullBackUpAsync(nameOfBackupSet);
            var kitchactorSvcTask = this._kitchenActorServiceBackupRestoreManager.TakeFullBackupAsync(nameOfBackupSet);
            var orderActorSvcTask = this._orderActorServiceBackupRestoreManager.TakeFullBackupAsync(nameOfBackupSet);
            var tableActorSvcTask = this._tableActorServiceBackupRestoreManager.TakeFullBackupAsync(nameOfBackupSet);
            await restaurantSvcTask;
            await menuSvcTask;
            await kitchactorSvcTask;
            await orderActorSvcTask;
            await tableActorSvcTask;
            return "Backup succeeded! Name of backupset: " + nameOfBackupSet ;

        }

        
    }
}

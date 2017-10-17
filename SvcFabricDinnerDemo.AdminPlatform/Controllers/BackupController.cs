using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SvcFabricDinnerDemo.DinnerMenuService.Interfaces;
using SvcFabricDinnerDemo.RestaurantService.Interfaces;

namespace SvcFabricDinnerDemo.AdminPlatform.Controllers
{
    [Route("api/[controller]")]
    public class BackupController : Controller
    {
        private readonly IRestaurantBackupRestoreManager _restaurantBackupRestoreManager;
        private readonly IDinnerMenuBackupRestoreManager _dinnerMenuBackupRestoreManager;

        public  BackupController (IRestaurantBackupRestoreManager restaurantBackupRestoreManager,
            IDinnerMenuBackupRestoreManager dinnerMenuBackupRestoreManager)
        {
            _restaurantBackupRestoreManager = restaurantBackupRestoreManager;
            _dinnerMenuBackupRestoreManager = dinnerMenuBackupRestoreManager;
        }

        // GET api/values/5
        [HttpPost]
        public async Task<string> Post(string nameOfBackupSet)
        {
            var menuSvcTask = this._dinnerMenuBackupRestoreManager.TakeFullBackUpAsync(nameOfBackupSet);
            var restaurantSvcTask = this._restaurantBackupRestoreManager.TakeFullBackUpAsync(nameOfBackupSet);
            await restaurantSvcTask;
            await menuSvcTask;
            return "Backup of backupset" + nameOfBackupSet + " succeeded!";

        }

        
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SvcFabricDinnerDemo.DinnerMenuService.Interfaces;
using SvcFabricDinnerDemo.RestaurantService.Interfaces;

namespace SvcFabricDinnerDemo.AdminPlatform.Controllers
{
    [Route("api/[controller]")]
    public class RestoreController : Controller
    {
        private readonly IRestaurantBackupRestoreManager _restaurantBackupRestoreManager;
        private readonly IDinnerMenuBackupRestoreManager _dinnerMenuBackupRestoreManager;

        public RestoreController(IRestaurantBackupRestoreManager restaurantBackupRestoreManager,
            IDinnerMenuBackupRestoreManager dinnerMenuBackupRestoreManager)
        {
            _restaurantBackupRestoreManager = restaurantBackupRestoreManager;
            _dinnerMenuBackupRestoreManager = dinnerMenuBackupRestoreManager;
        }


        // GET api/values/5
        [HttpPost()]
        public async Task<string> Post(string nameOfBackupSet)
        {
            var taskRestaurantSvc = this._restaurantBackupRestoreManager.RestoreFullBackUpAsync(nameOfBackupSet);
            var taskMenuSvc = this._dinnerMenuBackupRestoreManager.RestoreFullBackUpAsync(nameOfBackupSet);
            await taskRestaurantSvc;
            await taskMenuSvc;
            return "Restore of backupset " + nameOfBackupSet + " succeeded!";

        }


    }
}
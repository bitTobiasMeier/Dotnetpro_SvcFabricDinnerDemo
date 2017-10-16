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
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var taskRestaurantSvc = this._restaurantBackupRestoreManager.RestoreFullBackUpAsync(name);
            var taskMenuSvc = this._dinnerMenuBackupRestoreManager.RestoreFullBackUpAsync(name);
            await taskRestaurantSvc;
            await taskMenuSvc;
            return "Restore of backupset " + name + " succeeded!";

        }


    }
}
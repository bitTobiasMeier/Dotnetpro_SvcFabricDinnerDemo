using System;
using System.Text;
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
    public class RestoreController : Controller
    {
        private readonly IRestaurantBackupRestoreManager _restaurantBackupRestoreManager;
        private readonly IDinnerMenuBackupRestoreManager _dinnerMenuBackupRestoreManager;
        private readonly IOrderActorServiceBackupRestoreManager _orderActorServiceBackupRestoreManager;
        private readonly IKitchenActorServiceBackupRestoreManager _kitchenActorServiceBackupRestoreManager;
        private readonly ITableActorServiceBackupRestoreManager _tableActorServiceBackupRestoreManager;

        public RestoreController(IRestaurantBackupRestoreManager restaurantBackupRestoreManager,
            IDinnerMenuBackupRestoreManager dinnerMenuBackupRestoreManager,
            IOrderActorServiceBackupRestoreManager orderActorServiceBackupRestoreManager,
            IKitchenActorServiceBackupRestoreManager kitchenActorServiceBackupRestoreManager, 
            ITableActorServiceBackupRestoreManager tableActorServiceBackupRestoreManager)
        {
            _restaurantBackupRestoreManager = restaurantBackupRestoreManager;
            _dinnerMenuBackupRestoreManager = dinnerMenuBackupRestoreManager;
            _orderActorServiceBackupRestoreManager = orderActorServiceBackupRestoreManager;
            _kitchenActorServiceBackupRestoreManager = kitchenActorServiceBackupRestoreManager;
            _tableActorServiceBackupRestoreManager = tableActorServiceBackupRestoreManager;
        }


        // GET api/values/5
        [HttpPost()]
        public async Task<string> Post(string nameOfBackupSet)
        {
            var restaurantSvcTask = this._restaurantBackupRestoreManager.RestoreFullBackupAsync(nameOfBackupSet);
            var menuSvcTask = this._dinnerMenuBackupRestoreManager.RestoreFullBackupAsync(nameOfBackupSet);
            var kitchactorSvcTask =
                this._kitchenActorServiceBackupRestoreManager.RestoreFullBackupAsync(nameOfBackupSet);
            var orderActorSvcTask = this._orderActorServiceBackupRestoreManager.RestoreFullBackupAsync(nameOfBackupSet);
            var tableActorSvcTask = this._tableActorServiceBackupRestoreManager.RestoreFullBackupAsync(nameOfBackupSet);
            var sb = new StringBuilder();
            try
            {
                await restaurantSvcTask;
                sb.AppendLine("RestaurantSvc: Restored!");
            }
            catch (Exception ex)
            {
                sb.AppendLine("Error during restore of RestaurantSvc: " + ex.Message);
            }
            try
            {
                await menuSvcTask;
                sb.AppendLine("MenuSvc: Restored!");
            }
            catch (Exception ex)
            {
                sb.AppendLine("Error during restore of MenuSvc: " + ex.Message);
            }
            try
            {
                await kitchactorSvcTask;
                sb.AppendLine("KitchenActorSvc: Restored!");
            }
            catch (Exception ex)
            {
                sb.AppendLine("Error during restore of KitchenActorSvc: " + ex.Message);
            }
            try
            {
                await orderActorSvcTask;
                sb.AppendLine("OrderActorSvc: Restored!");
            }
            catch (Exception ex)
            {
                sb.AppendLine("Error during restore of OrderActorSvc: " + ex.Message);
            }
            try
            {
                await tableActorSvcTask;
                sb.AppendLine("TableActorSvc: Restored!");
            }
            catch (Exception ex)
            {
                sb.AppendLine("Error during restore of TableActorSvc: " + ex.Message);
            }
            return "Restoring backupset " + nameOfBackupSet + ". Result: \r\n" + sb.ToString();

        }


    }
}
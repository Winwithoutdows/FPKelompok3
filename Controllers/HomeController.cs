using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppRestaurantDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private Models.RestaurantDBEntities objRestaurantDbEntities;
        public HomeController()
        {
            objRestaurantDbEntities = new Models.RestaurantDBEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            Repositories.CustomerRepository objCustomerRepository = new Repositories.CustomerRepository();
            Repositories.ItemRepository objItemRepository = new Repositories.ItemRepository();
            Repositories.PaymentTypeRepository objPaymentTypeRepository = new Repositories.PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());
            return View(objMultipleModels);
        }
        [HttpGet]

        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRestaurantDbEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }
    }
}
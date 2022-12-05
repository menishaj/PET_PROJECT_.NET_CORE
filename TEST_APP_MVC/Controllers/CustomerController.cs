using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TEST_APP_MVC.Database;
using System.Web;

namespace TEST_APP_MVC.Controllers
{
    public class CustomerController : Controller
    {

        // GET: Customer
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: Customer

        public IActionResult Index()
        {
            var customers = from c in db.Customer
                            orderby c.Id
                            select c;
            return View(customers);
        }


    }
}

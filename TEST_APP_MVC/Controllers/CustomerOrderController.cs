using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using TEST_APP_MVC.Database;
using TEST_APP_MVC.Models;
using TEST_APP_MVC.Database.Models;
using Microsoft.AspNetCore.Http;
using TEST_APP_MVC.Helper;

namespace TEST_APP_MVC.Controllers
{
    public class CustomerOrderController : Controller
    {
        private readonly ISession session;

        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: CustomerOrder
        public ActionResult Index(string FirstName, string LastName)
        {
            var customers = from c in db.Customer
                            orderby c.Id
                            select c;
            return View(customers);
        }



        public ActionResult PlaceOrder( )
        {
            return View();
        }
        [HttpPost]
        public ActionResult PlaceOrder(string FirstName, string LastName)
        {

            var cust = db.Customer.Find(FirstName, LastName);
            //if customer does not exists, create customer
            //var customerr = Index(FirstName, LastName);
            string currentId = Guid.NewGuid().ToString();

            if (cust == null)
            {
                try
                {

                    db.Customer.Add(new Customer()
                    {
                        Id = currentId,
                        FirstName = FirstName,
                        LastName = LastName

                    });

                    db.SaveChanges();




                }
                catch (Exception ex)
                {
                    //Response.Write("<script>alert('Cannot place order');</script>");
                }
            }
            else
            {

                //RETURN Id
                currentId = cust.Id;


            }

            //insert order
            InsertOrder(currentId);

            return View();

        }



        public ActionResult InsertOrder(string CustomerId)

        {
            var cart = SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart");

            int? _sessionIntValue = HttpContext.Session.GetInt32("sessionKeyInt");


            var cartSessionx = SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart");

            if (SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart") == null)
            {

                var cartSession = SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart");

                var orderEntity = new Order();
                orderEntity.OrderDetails = JsonConvert.SerializeObject(cartSession);
                orderEntity.CustomerId = int.Parse(CustomerId);
                orderEntity.OrderedDate = DateTime.Now.ToString();

                orderEntity.TotalPrice = TotalPrice(cartSession);
                try
                {
                    db.Order.Add(orderEntity);
                    db.SaveChanges();
                }

                catch (Exception ex)
                {

                }
            }
            else
            {
                // nothing in cart
            }

            var menuList = new AllMenu
            {
                MenuList = cartSessionx
            };

            return View(menuList);
        }

        public int TotalPrice(List<Menu> SessionCart)
        {



            var total = 0;
            var menuEntities = from m in db.Menu orderby m.Id select m;
            foreach (var MenuItem in SessionCart)
            {
                var dbMenu = menuEntities.FirstOrDefault(i => i.Id == MenuItem.Id);

                if (dbMenu != null)
                {
                    total = total + (dbMenu.MealPrice * MenuItem.Quantity);


                }


            }
            return total;

        }




        public ActionResult FetchOrderDetailsByCId()
        {



            var fetchorders = "";
            // join c in db.Customer on o.CustomerId equals Order.Id
            // where c.Id == Order.CustomerId
            // select o.SingleOrDefault();
            return View(fetchorders);

        }
    }
}

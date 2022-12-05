﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_APP_MVC.Database;
using TEST_APP_MVC.Models;

namespace TEST_APP_MVC.Controllers
{
    public class AdminController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        //GET: Admin
        [Authorize]
        public ActionResult RetrieveAllOrders()
        {
            List<OrderInfo> OrderList = new List<OrderInfo>();
            //var fetchorderInfo = "(Select c.FirstName, c.LastName, o.OrderDetails from[Hangar.Restaurant.DB.2].[dbo].[CustomerEntity] c, [Hangar.Restaurant.DB.2].[dbo].[Order] o where c.Id = o.CustomerId);


            //OrderList.Add(Id); 

            var ordersFromDb =

            from order in db.Order.AsEnumerable()
            join customer in db.Customer.AsEnumerable()
            on order.CustomerId equals
                customer.Id.ToString()
            select new
            {
                OrderDetails =
                    order.OrderDetails,
                FirstName =
                    customer.FirstName,
                lastName =
                    customer.LastName,
                Total =
                    order.TotalPrice
            };

            if (ordersFromDb != null)
            {
                foreach (var order in ordersFromDb)
                {

                    OrderList.Add(new OrderInfo
                    {
                        CustomerDetails = new Customer
                        {
                            FirstName = order.FirstName,
                            LastName = order.lastName
                        },
                        OrderDetails = new Order
                        {
                            OrderDetails = order.OrderDetails,
                            TotalPrice = order.Total

                        }

                    });



                }

            }
            return View("Orders", OrderList);

        }
    }

}

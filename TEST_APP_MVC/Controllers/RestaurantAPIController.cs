
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_APP_MVC.Controllers
{
    public class RestaurantAPIController : Controller
    {
        public string Get()
        {


            return "OK";
            /* var order = new Customer {FirstName="Menisha",LastName="Jugoo"};

             if (order == null)
             {
                 return NotFound();
             }
             return Ok(order);
            */

        }
    }
}

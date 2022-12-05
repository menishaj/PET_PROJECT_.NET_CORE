using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TEST_APP_MVC.Database;
using TEST_APP_MVC.Helper;
using TEST_APP_MVC.Models;

namespace TEST_APP_MVC.Controllers
{
    public class MenuListController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: MenuList
        //public IActionResult Menu()
        //{
        private IQueryable<Order> Menu()
        {
            var menuList = GetMenuItems();
            return (IQueryable<Order>)View(menuList);
        }
        //}

        public IEnumerable<Order> GetMenu()
        {
            return Menu().AsEnumerable();
        }
        public ActionResult AddToCart(string itemId = null, string itemName = null)
        {
            var cart2 = SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart");
            if (!string.IsNullOrEmpty(itemId))
            {
                int id = Int32.Parse(itemId);
                if (SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart") == null)
                {
                    List<Menu> cart = new List<Menu>();
                    var menuitem = db.Menu.Find(id);
                    cart.Add(new Menu()
                    {
                        Id = menuitem.Id,
                        MealName = itemName,
                        Quantity = 1
                    });
                    SessionHelper.AddObjectToJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    //List<Menu> cart = (List<Menu>)Session["cart"];
                    List<Menu> cart = SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart");

                    var menuitem = db.Menu.Find(id);

                    var menuSelected = cart.FirstOrDefault(i => i.Id == id);
                    if (menuSelected != null)
                    {
                        cart.Remove(menuSelected);
                        menuSelected.Quantity++;

                        cart.Add(menuSelected);
                    }
                    else
                    {
                        cart.Add(new Menu()
                        {
                            Id = id,
                            Quantity = 1,
                            MealName = itemName

                        });
                    }
                    SessionHelper.AddObjectToJson(HttpContext.Session, "cart", cart);

                    // Session["cart"] = cart;
                }
            }
            var menuList = GetMenuItems();
            return View("Menu", menuList);
        }

        public List<Menu> GetMenuItems()
        {
            var menuEntities = from m in db.Menu orderby m.Id select m;

            var menuList = new List<Menu>();

            if (menuEntities != null && menuEntities.Any())
            {
                foreach (var currentMenu in menuEntities)
                {


                    var menu = new Menu();
                    menu.Id = currentMenu.Id;
                    menu.MealName = currentMenu.MealName;
                    //menu.MealPrice = currentMenu.MealPrice;
                    menuList.Add(menu);
                }

            }

            return menuList;
        }
    }

}


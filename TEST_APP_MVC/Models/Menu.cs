

using System.Collections.Generic;

namespace TEST_APP_MVC.Models
{
    public class Menu
    {

        public int Id { get; set; }
        public string MealName { get; set; }
        public int MealPrice { get; set; }
        public int Quantity { get; internal set; }
    }

    public class AllMenu
    {
        public List<Menu> MenuList { get; set; }
    }
}
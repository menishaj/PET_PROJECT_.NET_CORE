

namespace TEST_APP_MVC.Models
{
    public class Order
    {

        public int Id { get; set; }
        public string OrderDetails { get; set; }
        public string OrderedDate { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }

    }
}
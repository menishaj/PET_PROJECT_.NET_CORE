using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_APP_MVC.Database.Models
{
    public class OrderEntity
    {

        public int Id { get; set; }

        public string CustomerId { get; set; }

        public string OrderDetails { get; set; }

        public DateTime OrderedDate { get; set; }

        public int TotalPrice { get; set; }

    }
}

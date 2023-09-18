using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lession2.Models
{
    public class Order
    {
        private int OrderId;
        private int CustomerName;
        [Display(Name = "Ngày giờ")]
        private DateTime OrderDate;

        private List<OrderDetail> OrderDetails;
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
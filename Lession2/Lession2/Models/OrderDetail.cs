using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lession2.Models
{
    public class OrderDetail
    {
        private int OrderDetailId { get; set; }
        private int OrderId {  get; set; }
        private int ProductId { get; set; }
        [Display(Name = "Số lượng")]
        public  int Quantity { get; set; }
        [Display(Name = "Đơn giá")]
        public int UnitPrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
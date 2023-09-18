using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lession2.Models
{
    public class Product
    {
        private string ProductId;
        [Display(Name ="Tên sản phẩm")]
        private string Name;
        [Display(Name ="Giá bán")]
        private float Price;
        private List<OrderDetail> OrderDetails;
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }


}
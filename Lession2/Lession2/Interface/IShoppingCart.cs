using Lession2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession2.Interface
{
    internal interface IShoppingCart
    {
        void InsertCart(Product product);
        List<Product> GetList();
    }
}

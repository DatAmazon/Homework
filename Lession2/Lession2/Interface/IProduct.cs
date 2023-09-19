using Lession2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession2.Interface
{
    internal interface IProduct
    {
        void Insert(Product product);
        void Update(Product product);
        void Delete(int productId);
        List<Product> GetList();
    }
}

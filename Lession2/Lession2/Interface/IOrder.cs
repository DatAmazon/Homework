using Lession2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession2.Interface
{
    internal interface IOrder
    {
        void Insert(Order order);
        void Update(Order order);
        void Delete(int orderId);
        List<Order> GetList();
    }
}

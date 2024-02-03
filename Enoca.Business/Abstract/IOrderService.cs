using Enoca.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Abstract
{
    public interface IOrderService
    {
        Order Add(Order order);
        void Delete(int id);
        List<Order> GetAll();
    }
}

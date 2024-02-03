using Enoca.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
    }
}

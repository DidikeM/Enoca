using Enoca.DataAccess.Abstract;
using Enoca.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, EnocaCarrierContext>, IOrderDal
    {
        public EfOrderDal(IDbContextFactory<EnocaCarrierContext> contextFactory) : base(contextFactory)
        {
        }
    }
}

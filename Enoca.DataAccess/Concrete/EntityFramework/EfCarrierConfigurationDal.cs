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
    public class EfCarrierConfigurationDal : EfEntityRepositoryBase<CarrierConfiguration, EnocaCarrierContext>, ICarrierConfigurationDal
    {
        private readonly IDbContextFactory<EnocaCarrierContext> _contextFactory;
        public EfCarrierConfigurationDal(IDbContextFactory<EnocaCarrierContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public CarrierConfiguration? GetCarrierConfigurationWithCarrierFromClosestDesi(int orderDesi)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.CarrierConfigurations
                .Include(cc => cc.Carrier)
                .OrderBy(cc => cc.CarrierMaxDesi - orderDesi)
                .FirstOrDefault();
        }

        public CarrierConfiguration? GetMinCostCarrierConfigurationWithCarrierFromDesi(int orderDesi)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.CarrierConfigurations
                .Where(cc => cc.CarrierMinDesi <= orderDesi && orderDesi <= cc.CarrierMaxDesi)
                .Include(cc => cc.Carrier)
                .OrderBy(cc => cc.CarrierCost)
                .FirstOrDefault();
        }
    }
}

using Enoca.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Abstract
{
    public interface ICarrierConfigurationService
    {
        void Add(CarrierConfiguration carrierConfiguration);
        void Delete(int id);
        List<CarrierConfiguration> GetAll();
        void Update(CarrierConfiguration carrierConfiguration);
    }
}

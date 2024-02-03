using Enoca.Business.Abstract;
using Enoca.DataAccess.Abstract;
using Enoca.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Concrete
{
    public class CarrierConfigurationService : ICarrierConfigurationService
    {
        private readonly ICarrierConfigurationDal _carrierConfigurationDal;
        public CarrierConfigurationService(ICarrierConfigurationDal carrierConfigurationDal)
        {
            _carrierConfigurationDal = carrierConfigurationDal;
        }

        public void Add(CarrierConfiguration carrierConfiguration)
        {
            _carrierConfigurationDal.Add(carrierConfiguration);
        }

        public void Delete(int id)
        {
            var carriorConfiguration = _carrierConfigurationDal.Get(x => x.CarrierConfigurationId == id);
            _carrierConfigurationDal.Delete(carriorConfiguration);
        }

        public List<CarrierConfiguration> GetAll()
        {
            return _carrierConfigurationDal.GetAll();
        }

        public void Update(CarrierConfiguration carrierConfiguration)
        {
            _carrierConfigurationDal.Update(carrierConfiguration);
        }
    }
}

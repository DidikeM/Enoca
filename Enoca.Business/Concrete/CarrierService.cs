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
    public class CarrierService : ICarrierService
    {
        private readonly ICarrierDal _carrierDal;
        public CarrierService(ICarrierDal carrierDal)
        {
            _carrierDal = carrierDal;
        }

        public void Add(Carrier carrier)
        {
            _carrierDal.Add(carrier);
        }

        public void Delete(int id)
        {
            var carrier = _carrierDal.Get(p => p.CarrierId == id);
            _carrierDal.Delete(carrier);
        }

        public List<Carrier> GetAll()
        {
            return _carrierDal.GetAll();
        }

        public Carrier GetById(int id)
        {
            return _carrierDal.Get(p => p.CarrierId == id);
        }

        public void Update(Carrier carrier)
        {
            _carrierDal.Update(carrier);
        }
    }
}

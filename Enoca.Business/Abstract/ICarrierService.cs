using Enoca.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Abstract
{
    public interface ICarrierService
    {
        void Add(Carrier carrier);
        void Delete(int id);
        List<Carrier> GetAll();
        Carrier GetById(int id);
        void Update(Carrier carrier);
    }
}

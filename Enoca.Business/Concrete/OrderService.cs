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
    public class OrderService : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly ICarrierConfigurationDal _carrierConfigurationDal;

        public OrderService(IOrderDal orderDal, ICarrierConfigurationDal carrierConfigurationDal)
        {
            _orderDal = orderDal;
            _carrierConfigurationDal = carrierConfigurationDal;
        }

        public Order Add(Order order)
        {
            order.OrderTime = DateTime.Now;
            //var carrier = _carrierDal.GetMinCostCarrierWithCarrierConfiguration(order.OrderDesi);
            //_carrierDal.Any(c => c.CarrierConfigurations.Any(cc => cc.CarrierMinDesi < order.OrderDesi && order.OrderDesi < cc.CarrierMaxDesi))

            var carrierConfiguration = _carrierConfigurationDal.GetMinCostCarrierConfigurationWithCarrierFromDesi(order.OrderDesi);
            if (carrierConfiguration is not null)
            {
                order.CarrierId = carrierConfiguration.CarrierId;
                order.OrderCarrierCost = carrierConfiguration.CarrierCost;
            }
            else
            {
                carrierConfiguration = _carrierConfigurationDal.GetCarrierConfigurationWithCarrierFromClosestDesi(order.OrderDesi);
                if (carrierConfiguration is not null)
                {
                    order.CarrierId = carrierConfiguration.CarrierId;
                    order.OrderCarrierCost = carrierConfiguration.CarrierCost + carrierConfiguration.Carrier!.CarrierPlusDesiCost * (order.OrderDesi - carrierConfiguration.CarrierMaxDesi) ;
                }
                else
                {
                    throw new Exception("Kargo firması bulunamadı.");
                }
            }
            _orderDal.Add(order);
            return order;
        }

        public void Delete(int id)
        {
            var order = _orderDal.Get(x => x.OrderId == id);
            _orderDal.Delete(order);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
        }
    }
}

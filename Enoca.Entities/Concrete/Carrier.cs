using Enoca.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Entities.Concrete
{
    public class Carrier : IEntity
    {
        public int CarrierId { get; set; }
        public string CarrierName { get; set; } = null!;
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        //public int CarrierConfigurationId { get; set; } // what is this?
        public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; } = new List<CarrierConfiguration>();
        public ICollection<Order> Orders { get; set; } = new List<Order>(); 

    }
}

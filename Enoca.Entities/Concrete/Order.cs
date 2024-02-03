using Enoca.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int CarrierId { get; set; }
        public int OrderDesi { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal OrderCarrierCost { get; set; }
        public Carrier? Carrier { get; set; }
    }
}

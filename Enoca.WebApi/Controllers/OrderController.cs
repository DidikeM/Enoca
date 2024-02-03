using Enoca.Business.Abstract;
using Enoca.Business.Concrete;
using Enoca.Entities.Concrete;
using Enoca.WebApi.Dto.Order;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enoca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {

            _orderService = orderService;

        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Order> orders;
            try
            {
                orders = _orderService.GetAll();
            }
            catch (Exception e)
            {
                return BadRequest("Bir hata ile karşılaşıldı: " + e.Message);
            }
            return Ok(orders);
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] AddOrderDto addOrderDto)
        {
            Order order = new Order 
            {
                OrderDesi = addOrderDto.OrderDesi,
            };
            try
            {
                _orderService.Add(order);
            }
            catch (Exception e)
            {
                return BadRequest("Ekleme işlemi gerçekleştirilemedi: " + e.Message);
            }
            return Ok(new { message = "veri " + order.OrderId + " id numarası ile başarıyla eklendi." , order = order});
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _orderService.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest("Silme işlemi gerçekleştirilemedi: " + e.Message);
            }
            return Ok(id + " id'ye sahip veri başarıyla silindi.");
        }
    }
}

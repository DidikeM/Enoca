using Enoca.Business.Abstract;
using Enoca.Entities.Concrete;
using Enoca.WebApi.Dto.Carrier;
using Microsoft.AspNetCore.Mvc;
using System.Threading;


namespace Enoca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly ICarrierService _carrierService;
        public CarrierController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        // GET: api/<CarrierController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Carrier> carriers;
            try
            {
                carriers = _carrierService.GetAll();
            }
            catch (Exception e)
            {
                return BadRequest("Bir hata ile karşılaşıldı: " + e.Message);
            }
            return Ok(carriers);
        }

        // POST api/<CarrierController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCarrierDto addCarrierDto)
        {
            Carrier carrier = new Carrier
            {
                CarrierName = addCarrierDto.CarrierName,
                CarrierIsActive = addCarrierDto.CarrierIsActive,
                CarrierPlusDesiCost = addCarrierDto.CarrierPlusDesiCost
            };

            try
            {
                _carrierService.Add(carrier);
            }
            catch (Exception e)
            {
                return BadRequest("Ekleme işlemi gerçekleştirilemedi: " + e.Message);
            }
            return Ok("veri " + carrier.CarrierId + " id numarası ile başarıyla eklendi.");
        }

        // PUT api/<CarrierController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateCarrierDto updateCarrierDto)
        {
            Carrier carrier = new Carrier
            {
                CarrierId = updateCarrierDto.CarrierId,
                CarrierName = updateCarrierDto.CarrierName,
                CarrierIsActive = updateCarrierDto.CarrierIsActive,
                CarrierPlusDesiCost = updateCarrierDto.CarrierPlusDesiCost
            };
            try
            {
                _carrierService.Update(carrier);
            }
            catch (Exception e)
            {
                return BadRequest("Güncelleme işlemi gerçekleştirilemedi: " + e.Message);
            }
            return Ok(carrier.CarrierId + " id'ye sahip veri başarıyla güncellendi.");
        }

        // DELETE api/<CarrierController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _carrierService.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest("Silme işlemi gerçekleştirilemedi: " + e.Message);
            }
            return Ok(id + " id'ye sahip veri başarıyla silindi.");
        }
    }
}

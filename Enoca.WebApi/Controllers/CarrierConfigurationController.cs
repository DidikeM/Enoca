using Enoca.Business.Abstract;
using Enoca.Business.Concrete;
using Enoca.Entities.Concrete;
using Enoca.WebApi.Dto.CarrierConfiguration;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enoca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;
        public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        // GET: api/<CarrierConfigurationController>
        [HttpGet]
        public IActionResult Get()
        {
            List<CarrierConfiguration> carrierConfigurations;
            try
            {
                carrierConfigurations = _carrierConfigurationService.GetAll();
            }
            catch (Exception e)
            {
                return BadRequest("Bir hata ile karşılaşıldı: " + e.Message);
            }
            return Ok(carrierConfigurations);
        }

        //// GET api/<CarrierConfigurationController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CarrierConfigurationController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCarrierConfigurationDto addCarrierConfigurationDto)
        {
            CarrierConfiguration carrierConfiguration = new CarrierConfiguration
            {
                CarrierId = addCarrierConfigurationDto.CarrierId,
                CarrierMaxDesi = addCarrierConfigurationDto.CarrierMaxDesi,
                CarrierMinDesi = addCarrierConfigurationDto.CarrierMinDesi,
                CarrierCost = addCarrierConfigurationDto.CarrierCost
            };
            try
            {
                _carrierConfigurationService.Add(carrierConfiguration);
            }
            catch (Exception e)
            {
                return BadRequest("Ekleme işlemi gerçekleştirilemedi: " + e.Message);
            }
            return Ok("veri " + carrierConfiguration.CarrierConfigurationId + " id numarası ile başarıyla eklendi.");
        }

        // PUT api/<CarrierConfigurationController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateCarrierConfigurationDto updateCarrierConfigurationDto)
        {
            CarrierConfiguration carrierConfiguration = new CarrierConfiguration
            {
                CarrierConfigurationId = updateCarrierConfigurationDto.CarrierConfigurationId,
                CarrierId = updateCarrierConfigurationDto.CarrierId,
                CarrierMaxDesi = updateCarrierConfigurationDto.CarrierMaxDesi,
                CarrierMinDesi = updateCarrierConfigurationDto.CarrierMinDesi,
                CarrierCost = updateCarrierConfigurationDto.CarrierCost
            };
            try
            {
                _carrierConfigurationService.Update(carrierConfiguration);
            }
            catch (Exception e)
            {
                return BadRequest("Güncelleme işlemi gerçekleştirilemedi: " + e.Message);
            }
            return Ok(carrierConfiguration.CarrierConfigurationId + " id'ye sahip veri başarıyla güncellendi.");
        }

        // DELETE api/<CarrierConfigurationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _carrierConfigurationService.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest("Silme işlemi gerçekleştirilemedi: " + e.Message);
            }
            return Ok(id + " id'ye sahip veri başarıyla silindi.");
        }
    }
}

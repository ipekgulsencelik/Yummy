using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Business.Abstract;
using Yummy.DTO.DTOs.ServiceDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(IMapper _mapper, IServiceService _serviceService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetServiceList()
        {
            var services = _serviceService.TGetList();
            var result = _mapper.Map<List<ResultServiceDTO>>(services);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDTO createServiceDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newService = _mapper.Map<Service>(createServiceDTO);
            _serviceService.TCreate(newService);
            return CreatedAtAction(nameof(GetServiceByID), new { id = newService.ServiceID }, newService);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            _serviceService.TDelete(id);
            return Ok("Hizmet Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceByID(int id)
        {
            var service = _serviceService.TGetByID(id);
            if (service == null)
            {
                return NotFound("Hizmet Bulunamadı.");
            }

            return Ok(service);
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDTO updateServiceDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var service = _mapper.Map<Service>(updateServiceDTO);
            _serviceService.TUpdate(service);
            return Ok("Hizmet Güncellendi");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetActiveServices()
        {
            var services = _serviceService.TGetFilteredList(x => x.IsActive == true);
            return Ok(services);
        }

        [AllowAnonymous]
        [HttpGet("last-three-active")]
        public IActionResult GetLast3Services()
        {
            var services = _serviceService.TGetFilteredList(x => x.IsActive && x.IsVisible)
                                           .OrderByDescending(x => x.ServiceID)
                                           .Take(3);
            return Ok(services);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetServiceCount()
        {
            var serviceCount = _serviceService.TCount();
            return Ok(serviceCount);
        }

        [HttpPut("set-visible/{id}")]
        public IActionResult SetServiceVisibleOnHome(int id)
        {
            _serviceService.TSetServiceVisibleOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpPut("set-hidden/{id}")]
        public IActionResult SetServiceHiddenOnHome(int id)
        {
            _serviceService.TSetServiceHiddenOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("visible-on-home")]
        public IActionResult GetServicesVisibleOnHome()
        {
            var services = _serviceService.TGetFilteredList(x => x.IsActive && x.IsVisible);
            return Ok(services);
        }

        [HttpPut("toggle-status/{id}")]
        public IActionResult ToggleServiceStatus(int id)
        {
            _serviceService.TToggleServiceStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}
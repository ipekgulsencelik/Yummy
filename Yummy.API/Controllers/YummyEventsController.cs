using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Business.Abstract;
using Yummy.DTO.DTOs.YummyEventDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController(IMapper _mapper, IYummyEventService _organizationService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetYummyEventList()
        {
            var organizations = _organizationService.TGetList();
            var result = _mapper.Map<List<ResultYummyEventDTO>>(organizations);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(CreateYummyEventDTO createYummyEventDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newYummyEvent = _mapper.Map<YummyEvent>(createYummyEventDTO);
            _organizationService.TCreate(newYummyEvent);
            return CreatedAtAction(nameof(GetYummyEventByID), new { id = newYummyEvent.YummyEventID }, newYummyEvent);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteYummyEvent(int id)
        {
            _organizationService.TDelete(id);
            return Ok("Etkinlik Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetYummyEventByID(int id)
        {
            var organization = _organizationService.TGetByID(id);
            if (organization == null)
            {
            return NotFound("Etkinlik Bulunamadı.");
            }

            return Ok(organization);
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(UpdateYummyEventDTO updateYummyEventDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var organization = _mapper.Map<YummyEvent>(updateYummyEventDTO);
            _organizationService.TUpdate(organization);
            return Ok("Etkinlik Güncellendi");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetActiveYummyEvents()
        {
            var organizations = _organizationService.TGetFilteredList(x => x.IsActive == true);
            return Ok(organizations);
        }

        [AllowAnonymous]
        [HttpGet("last-four-active")]
        public IActionResult GetLast4YummyEvents()
        {
            var organization = _organizationService.TGetFilteredList(x => x.IsActive && x.IsVisible).OrderByDescending(x => x.YummyEventID).Take(4);
            return Ok(organization);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetYummyEventCount()
        {
            var organizationCount = _organizationService.TCount();
            return Ok(organizationCount);
        }

        [HttpPut("set-visible/{id}")]
        public IActionResult SetYummyEventVisibleOnHome(int id)
        {
            _organizationService.TSetYummyEventVisibleOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpPut("set-hidden/{id}")]
        public IActionResult SetYummyEventHiddenOnHome(int id)
        {
            _organizationService.TSetYummyEventHiddenOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("visible-on-home")]
        public IActionResult GetYummyEventsVisibleOnHome()
        {
            var organization = _organizationService.TGetFilteredList(x => x.IsActive && x.IsVisible);
            return Ok(organization);
        }

        [HttpPut("toggle-status/{id}")]
        public IActionResult ToggleYummyEventStatus(int id)
        {
            _organizationService.TToggleYummyEventStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}
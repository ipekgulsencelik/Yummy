using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Business.Abstract;
using Yummy.DTO.DTOs.ChefDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController(IMapper _mapper, IChefService _chefService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetChefList()
        {
            var chefs = _chefService.TGetList();
            var result = _mapper.Map<List<ResultChefDTO>>(chefs);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateChef(CreateChefDTO createChefDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newChef = _mapper.Map<Chef>(createChefDTO);
            _chefService.TCreate(newChef);
            return CreatedAtAction(nameof(GetChefByID), new { id = newChef.ChefID }, newChef);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChef(int id)
        {
            _chefService.TDelete(id);
            return Ok("Şef Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetChefByID(int id)
        {
            var chef = _chefService.TGetByID(id);
            if (chef == null)
            {
                return NotFound("Şef bulunamadı.");
            }

            return Ok(chef);
        }

        [HttpPut]
        public IActionResult UpdateChef(UpdateChefDTO updateChefDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var chef = _mapper.Map<Chef>(updateChefDTO);            
            _chefService.TUpdate(chef);
            return Ok("Şef Güncellendi");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetActiveChefs()
        {
            var chefs = _chefService.TGetFilteredList(x => x.IsActive == true);
            return Ok(chefs);
        }

        [AllowAnonymous]
        [HttpGet("last-three-active")]
        public IActionResult GetLast3Chefs()
        {
            var chefs = _chefService.TGetFilteredList(x => x.IsActive && x.IsVisible).OrderByDescending(x => x.ChefID).Take(3);
            return Ok(chefs);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetChefCount()
        {
            var chefCount = _chefService.TCount();
            return Ok(chefCount);
        }

        [HttpPut("set-visible/{id}")]
        public IActionResult SetChefVisibleOnHome(int id)
        {
            _chefService.TSetChefVisibleOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpPut("set-hidden/{id}")]
        public IActionResult SetChefHiddenOnHome(int id)
        {
            _chefService.TSetChefHiddenOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("visible-on-home")]
        public IActionResult GetChefsVisibleOnHome()
        {
            var chefs = _chefService.TGetFilteredList(x => x.IsActive && x.IsVisible);
            return Ok(chefs);
        }

        [HttpPut("toggle-status/{id}")]
        public IActionResult ToggleChefStatus(int id)
        {
            _chefService.TToggleChefStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}
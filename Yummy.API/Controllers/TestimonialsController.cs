using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Business.Abstract;
using Yummy.DTO.DTOs.TestimonialDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IMapper _mapper, ITestimonialService _testimonialService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTestimonialList()
        {
            var testimonials = _testimonialService.TGetList();
            var result = _mapper.Map<List<ResultTestimonialDTO>>(testimonials);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newTestimonial = _mapper.Map<Testimonial>(createTestimonialDTO);
            _testimonialService.TCreate(newTestimonial);
            return CreatedAtAction(nameof(GetTestimonialByID), new { id = newTestimonial.TestimonialID }, newTestimonial);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Referans Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonialByID(int id)
        {
            var testimonial = _testimonialService.TGetByID(id);
            if (testimonial == null)
            {
                return NotFound("Referans Bulunamadı.");
            }

            return Ok(testimonial);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDTO);
            _testimonialService.TUpdate(testimonial);
            return Ok("Referans Güncellendi");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetActiveTestimonials()
        {
            var testimonials = _testimonialService.TGetFilteredList(x => x.IsActive == true);
            return Ok(testimonials);
        }

        [AllowAnonymous]
        [HttpGet("last-four-active")]
        public IActionResult GetLast4Testimonials()
        {
            var testimonial = _testimonialService.TGetFilteredList(x => x.IsActive && x.IsVisible).OrderByDescending(x => x.TestimonialID).Take(4);
            return Ok(testimonial);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetTestimonialCount()
        {
            var testimonialCount = _testimonialService.TCount();
            return Ok(testimonialCount);
        }

        [HttpPut("set-visible/{id}")]
        public IActionResult SetTestimonialVisibleOnHome(int id)
        {
            _testimonialService.TSetTestimonialVisibleOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpPut("set-hidden/{id}")]
        public IActionResult SetTestimonialHiddenOnHome(int id)
        {
            _testimonialService.TSetTestimonialHiddenOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("visible-on-home")]
        public IActionResult GetTestimonialsVisibleOnHome()
        {
            var testimonial = _testimonialService.TGetFilteredList(x => x.IsActive && x.IsVisible);
            return Ok(testimonial);
        }

        [HttpPut("toggle-status/{id}")]
        public IActionResult ToggleTestimonialStatus(int id)
        {
            _testimonialService.TToggleTestimonialStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}
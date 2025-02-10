using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Business.Abstract;
using Yummy.DTO.DTOs.CategoryDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IMapper _mapper, ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            var values = _categoryService.TGetList();
            var result = _mapper.Map<List<ResultCategoryDTO>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newCategory = _mapper.Map<Category>(createCategoryDTO);            
            _categoryService.TCreate(newCategory);
            return Ok("Yeni Kategori Oluşturuldu");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            var category = _categoryService.TGetByID(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı.");
            }

            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var value = _mapper.Map<Category>(updateCategoryDTO);            
            _categoryService.TUpdate(value);
            return Ok("Kategori Güncellendi");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetActiveCategories()
        {
            var values = _categoryService.TGetFilteredList(x => x.IsActive == true);
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetCategoryCount()
        {
            var categoryCount = _categoryService.TCount();
            return Ok(categoryCount);
        }

        [HttpPut("set-visible/{id}")]
        public IActionResult SetCategoryVisibleOnHome(int id)
        {
            _categoryService.TSetCategoryVisibleOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpPut("set-hidden/{id}")]
        public IActionResult SetCategoryHiddenOnHome(int id)
        {
            _categoryService.TSetCategoryHiddenOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("visible-on-home")]
        public IActionResult GetCategoriesVisibleOnHome()
        {
            var value = _categoryService.TGetFilteredList(x => x.IsActive && x.IsVisible);
            return Ok(value);
        }

        [HttpPut("toggle-status/{id}")]
        public IActionResult ToggleCategoryStatus(int id)
        {
            _categoryService.TToggleCategoryStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}
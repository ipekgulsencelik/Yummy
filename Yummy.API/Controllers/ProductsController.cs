using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Business.Abstract;
using Yummy.DTO.DTOs.ProductDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IValidator<CreateProductDTO> _validator, IMapper _mapper, IProductService _productService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProductList()
        {
            var values = _productService.TGetList();
            var result = _mapper.Map<List<ResultProductDTO>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO createProductDTO)
        {
            var validaitonResult = _validator.Validate(createProductDTO);
            if (!validaitonResult.IsValid)
            {
                return BadRequest(validaitonResult.Errors.Select(x => x.ErrorMessage));
            }

            var newProduct = _mapper.Map<Product>(createProductDTO);
            _productService.TCreate(newProduct);

            return CreatedAtAction(nameof(CreateProduct), new { id = newProduct.ProductID }, new
            {
                message = "Ürün ekleme işlemi başarılı",
                data = newProduct
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Kategori Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProductByID(int id)
        {
            var product = _productService.TGetByID(id);
            if (product == null)
            {
                return NotFound("Kategori bulunamadı.");
            }

            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var value = _mapper.Map<Product>(updateProductDTO);
            _productService.TUpdate(value);
            return Ok("Kategori Güncellendi");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetActiveCategories()
        {
            var values = _productService.TGetFilteredList(x => x.IsActive == true);
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetProductCount()
        {
            var productCount = _productService.TCount();
            return Ok(productCount);
        }

        [HttpPut("set-visible/{id}")]
        public IActionResult SetProductVisibleOnHome(int id)
        {
            _productService.TSetProductVisibleOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpPut("set-hidden/{id}")]
        public IActionResult SetProductHiddenOnHome(int id)
        {
            _productService.TSetProductHiddenOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("visible-on-home")]
        public IActionResult GetCategoriesVisibleOnHome()
        {
            var value = _productService.TGetFilteredList(x => x.IsActive && x.IsVisible);
            return Ok(value);
        }

        [HttpPut("toggle-status/{id}")]
        public IActionResult ToggleProductStatus(int id)
        {
            _productService.TToggleProductStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}
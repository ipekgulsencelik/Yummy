using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Business.Abstract;
using Yummy.DTO.DTOs.FeatureDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IMapper _mapper, IFeatureService _featureService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFeatureList()
        {
            var features = _featureService.TGetList();
            var result = _mapper.Map<List<ResultFeatureDTO>>(features);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newFeature = _mapper.Map<Feature>(createFeatureDTO);
            _featureService.TCreate(newFeature);
            return CreatedAtAction(nameof(GetFeatureByID), new { id = newFeature.FeatureID }, newFeature);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(id);
            return Ok("Öne Çıkan Bilgisi Verisi Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeatureByID(int id)
        {
            var feature = _featureService.TGetByID(id);
            if (feature == null)
            {
                return NotFound("Öne Çıkan Bilgisi Verisi Bulunamadı.");
            }

            return Ok(feature);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var feature = _mapper.Map<Feature>(updateFeatureDTO);
            _featureService.TUpdate(feature);
            return Ok("Öne Çıkan Bilgisi Verisi Güncellendi");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetActiveFeatures()
        {
            var features = _featureService.TGetFilteredList(x => x.IsActive == true);
            return Ok(features);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetFeatureCount()
        {
            var featureCount = _featureService.TCount();
            return Ok(featureCount);
        }

        [HttpPut("set-visible/{id}")]
        public IActionResult SetFeatureVisibleOnHome(int id)
        {
            _featureService.TSetFeatureVisibleOnHome(id);
            return Ok("Öne Çıkan Bilgisi Verisi Ana Sayfada Gösteriliyor");
        }

        [HttpPut("set-hidden/{id}")]
        public IActionResult SetFeatureHiddenOnHome(int id)
        {
            _featureService.TSetFeatureHiddenOnHome(id);
            return Ok("Öne Çıkan Bilgisi Verisi Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("visible-on-home")]
        public IActionResult GetFeaturesVisibleOnHome()
        {
            var features = _featureService.TGetFilteredList(x => x.IsActive && x.IsVisible);
            return Ok(features);
        }

        [HttpPut("toggle-status/{id}")]
        public IActionResult ToggleFeatureStatus(int id)
        {
            _featureService.TToggleFeatureStatus(id);
            return Ok("Öne Çıkan Verisi Durum Bilgisi Değiştirildi.");
        }
    }
}
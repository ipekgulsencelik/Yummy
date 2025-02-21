using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Business.Abstract;
using Yummy.DTO.DTOs.ContactDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IMapper _mapper, IContactService _contactService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetContactList()
        {
            var contacts = _contactService.TGetList();
            var result = _mapper.Map<List<ResultContactDTO>>(contacts);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newContact = _mapper.Map<Contact>(createContactDTO);
            _contactService.TCreate(newContact);
            return CreatedAtAction(nameof(GetContactByID), new { id = newContact.ContactID }, newContact);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return Ok("Şef Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContactByID(int id)
        {
            var contact = _contactService.TGetByID(id);
            if (contact == null)
            {
                return NotFound("Şef bulunamadı.");
            }

            return Ok(contact);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contact = _mapper.Map<Contact>(updateContactDTO);
            _contactService.TUpdate(contact);
            return Ok("Şef Güncellendi");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetActiveContacts()
        {
            var contacts = _contactService.TGetFilteredList(x => x.IsActive == true);
            return Ok(contacts);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetContactCount()
        {
            var contactCount = _contactService.TCount();
            return Ok(contactCount);
        }

        [HttpPut("set-visible/{id}")]
        public IActionResult SetContactVisibleOnHome(int id)
        {
            _contactService.TSetContactVisibleOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpPut("set-hidden/{id}")]
        public IActionResult SetContactHiddenOnHome(int id)
        {
            _contactService.TSetContactHiddenOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("visible-on-home")]
        public IActionResult GetContactsVisibleOnHome()
        {
            var contacts = _contactService.TGetFilteredList(x => x.IsActive && x.IsVisible);
            return Ok(contacts);
        }
    }
}
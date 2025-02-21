using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Business.Abstract;
using Yummy.DTO.DTOs.MessageDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IMapper _mapper, IMessageService _messageService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessageList()
        {
            var messages = _messageService.TGetList();
            var result = _mapper.Map<List<ResultMessageDTO>>(messages);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newMessage = _mapper.Map<Message>(createMessageDTO);
            _messageService.TCreate(newMessage);
            return CreatedAtAction(nameof(GetMessageByID), new { id = newMessage.MessageID }, newMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return Ok("Mesaj Bilgisi Verisi Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageByID(int id)
        {
            var message = _messageService.TGetByID(id);
            if (message == null)
            {
                return NotFound("Mesaj Bilgisi Verisi Bulunamadı.");
            }

            return Ok(message);
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var message = _mapper.Map<Message>(updateMessageDTO);
            _messageService.TUpdate(message);
            return Ok("Mesaj Bilgisi Verisi Güncellendi.");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetReadMessages()
        {
            var messages = _messageService.TGetFilteredList(x => x.IsRead == true);
            return Ok(messages);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetMessageCount()
        {
            var messageCount = _messageService.TCount();
            return Ok(messageCount);
        }

        [HttpPut("set-read/{id}")]
        public async Task<IActionResult> SetMessageAsRead(int id)
        {
            var message = _messageService.TGetByID(id);
            if (message == null)
            {
                return NotFound("Mesaj Bilgisi Verisi Bulunamadı.");
            }

            await _messageService.TMarkMessageAsRead(id);
            return Ok(new { message = "Mesaj Okundu Olarak işaretlendi." });
        }

        [HttpPut("set-unread/{id}")]
        public async Task<IActionResult> SetMessageAsUnread(int id)
        {
            var message = _messageService.TGetByID(id);
            if (message == null)
            {
                return NotFound("Mesaj Bilgisi Verisi Bulunamadı.");
            }

            await _messageService.TMarkMessageAsUnread(id);
            return Ok(new { message = "Mesaj Okunmamış Olarak işaretlendi." });
        }
    }
}
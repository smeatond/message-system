using MessageWeb.Models;
using MessageWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly MessageService _messageService;

    public MessageController(MessageService messageService) =>
        _messageService = messageService;

    [HttpGet]
    public async Task<List<Message>> Get() =>
        await _messageService.GetAsync();


    [HttpPost]
    public async Task<IActionResult> Message(Message newMessage)
    {
        await _messageService.CreateAsync(newMessage);

        return CreatedAtAction(nameof(Get), new { id = newMessage.Id }, newMessage);
    }

}
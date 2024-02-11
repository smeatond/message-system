using MessageWeb.Models;
using MessageWeb.Services;
using Microsoft.AspNetCore.SignalR;

namespace MessageWeb.Hubs
{
    public class MessageHub : Hub
    {
         private readonly MessageService _messageService;

    public MessageHub(MessageService messageService) =>
        _messageService = messageService;
        public async Task SendMessage(string user, string message)
        {
            var datetime = new DateTime();
            var newMessage = new Message{MessageText = message, Username = user, DateTime = datetime};
            await _messageService.CreateAsync(newMessage);
            await Clients.All.SendAsync("ReceiveMessage", user, message, datetime);
        }
    }
}
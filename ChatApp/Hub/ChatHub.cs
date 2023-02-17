using ChatApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public const string ReceiveMessage = "ReceiveMessage";
        public async Task SendMessage(ChatMessage msg)
        {
            Clients.All.SendAsync(ReceiveMessage, msg);
        }
    }
}

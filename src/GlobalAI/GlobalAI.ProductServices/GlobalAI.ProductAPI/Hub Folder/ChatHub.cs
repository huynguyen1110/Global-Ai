using Microsoft.AspNetCore.SignalR;

namespace GlobalAI.ProductAPI.HubFolder
{
    public class ChatHub : Hub<IMessageHubClient>
    {
        public async Task SendMessageToUser(string message)
        {
            await Clients.All.SendMessageToUser(message);
        }
    }
}

/*using GlobalAI.ProductAPI.HubFolder;*/
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GlobalAI.ProductAPI.Controllers
{
    /*[Route("api/product")]
    [ApiController]
    public class TestSignalRController : BaseController
    {
        private IHubContext<ChatHub, IMessageHubClient> _messageHub;

        public TestSignalRController(IHubContext<ChatHub, IMessageHubClient> messageHub)
        {
            _messageHub = messageHub;
        }
        [HttpPost]
        [Route("productoffers")]
        public IActionResult SendMessage(string mess)
        {
            _messageHub.Clients.All.SendMessageToUser(mess);
            return Ok("Gửi thành công");
        }
    }*/
}

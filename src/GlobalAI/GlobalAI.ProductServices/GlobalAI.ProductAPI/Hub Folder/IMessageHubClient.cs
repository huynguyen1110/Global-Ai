namespace GlobalAI.ProductAPI.HubFolder
{
    public interface IMessageHubClient
    {
        Task SendMessageToUser(string message);
    }
}

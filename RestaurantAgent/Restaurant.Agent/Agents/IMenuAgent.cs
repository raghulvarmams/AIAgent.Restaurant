namespace Restaurant.Agent.Agents
{
    public interface IMenuAgent
    {
        Task<string> ProcessRequestAsync(string request, RestaurantConversationContext context);
    }
}

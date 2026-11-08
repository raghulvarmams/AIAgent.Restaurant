namespace Restaurant.Agent.Agents
{
    public interface ICoordinatorAgent
    {
        Task<string> ProcessRequestAsync(string request, RestaurantConversationContext context);
    }
}

namespace Restaurant.Agent.Agents
{
    public interface IReservationAgent
    {
        Task<string> ProcessRequestAsync(string request, RestaurantConversationContext context);
    }
}

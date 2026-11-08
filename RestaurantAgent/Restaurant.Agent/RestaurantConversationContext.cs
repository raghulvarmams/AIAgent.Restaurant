using Microsoft.SemanticKernel.ChatCompletion;

namespace Restaurant.Agent
{
    public class RestaurantConversationContext
    {
        public ChatHistory ChatHistory { get; } = new();

        public bool IsVegan { get; set; }

        public bool IsVegetarian { get; set; }

        public DateTime? ReservationTime { get; set; }

        public List<string> SuggestedDishes { get; set; } = [];
    }
}

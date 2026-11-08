using Microsoft.SemanticKernel;

namespace Restaurant.Agent.Agents
{
    public class ReservationAgent : BaseAgent, IReservationAgent
    {
        protected override string Instructions =>
 """
You are a Reservation Specialist Agent for a restaurant.

Responsibilities:
- Create reservations.
- Modify reservations.
- Cancel reservations.
- Answer questions about reservation availability.

Rules:
- Use reservation tools whenever reservation information is required.
- Do not make assumptions about availability.
- Confirm important reservation details before completing a booking.
- Use information from tools and shared context.

You are NOT responsible for:
- Menu recommendations.
- Ingredients.
- Dish descriptions.
- Food suggestions.
""";

        public ReservationAgent(Kernel kernel) : base(kernel)
        {

        }

        public async Task<string> ProcessRequestAsync(string request, RestaurantConversationContext context)
        {
            return await ExecuteAsync(request, context);
        }
    }
}

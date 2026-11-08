using Microsoft.SemanticKernel;
using System.Text.Json;

namespace Restaurant.Agent.Agents
{
    public class CoordinatorAgent : ICoordinatorAgent
    {
        private readonly IMenuAgent _menuAgent;
        private readonly IReservationAgent _reservationAgent;

        private Kernel _kernel;

        public CoordinatorAgent(IMenuAgent menuAgent, IReservationAgent reservationAgent, Kernel kernel)
        {
            _menuAgent = menuAgent;
            _reservationAgent = reservationAgent;
            _kernel = kernel;
        }

        public async Task<string> ProcessRequestAsync(string request, RestaurantConversationContext context)
        {
            // string agentsToBeCalled = await DetermineAgentAsync(request, _kernel);
            //var agents = agentsToBeCalled.Split(',', StringSplitOptions.RemoveEmptyEntries)
            //           .Select(x => x.Trim());
            
            List<AgentTask> tasks = await DecomposeRequestAsync(request);
            var responses = new List<string>();
            foreach (var taskItem in tasks)
            {
                switch (taskItem.AgentName)
                {
                    case "ReservationAgent":
                        responses.Add(await _reservationAgent.ProcessRequestAsync(taskItem.TaskDescription, context));
                        break;
                    case "MenuAgent":
                        responses.Add(await _menuAgent.ProcessRequestAsync(taskItem.TaskDescription, context));
                        break;
                    default:
                        break;
                }
            }
           
            return string.Join(Environment.NewLine + Environment.NewLine, responses);
        }

        private async Task<string> DetermineAgentAsync(string request, Kernel _kernel)
        {
            string routingPrompt =
                                   """
You are an agent router.

Available Agents:

MenuAgent
- Menu questions
- Food recommendations
- Ingredients
- Vegan dishes
- Vegetarian dishes

ReservationAgent
- Table bookings
- Reservations
- Table availability

A request may require MORE THAN ONE AGENT.

Return only agent names separated by commas.

Examples:

Request:
Show vegan dishes

Return:
MenuAgent

Request:
Book a table for 4

Return:
ReservationAgent

Request:
Book a table for 4 and suggest vegan dishes

Return:
ReservationAgent,MenuAgent

Request:
{{$request}}

Return only the agent names.
""";

            var result =
                await _kernel.InvokePromptAsync(routingPrompt,
                            new KernelArguments
                            {
                                ["request"] = request
                            });

            return result.ToString().Trim();
        }

        private async Task<List<AgentTask>> DecomposeRequestAsync(string request)
        {
            string prompt =
            """
        You are a coordinator agent.

        Available Agents:

        MenuAgent
        - Menu recommendations
        - Vegan dishes
        - Vegetarian dishes
        - Non vegetarian dishes
        - Ingredients
        - Drinks
        - Combos

        ReservationAgent
        - Table booking
        - Table cancellation
        - Reservation modifications
        - Reservation availability

        Break the customer request into tasks.

        Return ONLY valid JSON.

        Example:

        [
          {
            "AgentName":"ReservationAgent",
            "TaskDescription":"Book a table for 4 people"
          },
          {
    
            "AgentName":"MenuAgent",
            "TaskDescription":"Suggest vegan dishes"
          }
        ]

        Customer Request:
        {{$request}}
        """;
            var result =
                await _kernel.InvokePromptAsync(
                                                prompt, 
                                                new KernelArguments
                                                {
                                                    ["request"] = request
                                                });

            try
            {
                return JsonSerializer.Deserialize<List<AgentTask>>(
                           result.ToString())
                       ?? [];
            }
            catch
            {
                return [];
            }
        }
    }
}

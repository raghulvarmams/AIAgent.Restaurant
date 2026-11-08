
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Agent;
using Restaurant.Agent.Agents;
using RestaurantApplication;

AddServiceLayer addServiceLayer = new();
var provider = addServiceLayer.ConfigureServices();
var coordinatorAgent = provider.GetRequiredService<ICoordinatorAgent>();
var conversationContext = new RestaurantConversationContext();

Console.WriteLine("Restaurant Assistant Started");
Console.WriteLine("Type 'exit' to quit");


while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Customer: ");

    var prompt = Console.ReadLine();

    if (string.Equals(prompt, "exit",
        StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    var result = await coordinatorAgent.ProcessRequestAsync(prompt!, conversationContext);

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Agent : { result }");
    Console.WriteLine();
}
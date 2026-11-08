using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace Restaurant.Agent.Agents
{
    public abstract class BaseAgent
    {
        private readonly Kernel _kernel;

        protected abstract string Instructions { get; }

        public BaseAgent(Kernel kernel)
        {
            _kernel = kernel;
        }

        public async Task<string> ExecuteAsync(string request, RestaurantConversationContext context)
        {
            var chatService =
           _kernel.GetRequiredService<IChatCompletionService>();

            var agentHistory = new ChatHistory();
            // Agent-specific instructions
            agentHistory.AddSystemMessage(Instructions);

            // Existing conversation
            foreach (var message in context.ChatHistory)
            {
                agentHistory.Add(message);
            }

            agentHistory.AddUserMessage(request);
         
            var settings = new OpenAIPromptExecutionSettings
            {
                FunctionChoiceBehavior =
            FunctionChoiceBehavior.Auto()
            };

            var result = await chatService.GetChatMessageContentAsync(
                            agentHistory,
                            settings,
                            _kernel);

            context.ChatHistory.AddAssistantMessage(
                result.Content ?? string.Empty);

            return result.Content ?? string.Empty;
        }
    }
}

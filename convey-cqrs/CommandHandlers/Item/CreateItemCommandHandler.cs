using System.Threading.Tasks;
using Convey.CQRS.Commands;
using convey_cqrs.Commands.Item;
using Microsoft.Extensions.Logging;

namespace convey_cqrs.CommandHandlers.Item
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        private readonly ILogger<CreateItemCommandHandler> _logger;

        public CreateItemCommandHandler(ILogger<CreateItemCommandHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(CreateItemCommand command)
        {
            _logger.LogInformation($"Create Item {command.Id}");
            return Task.CompletedTask;
        }
    }
}
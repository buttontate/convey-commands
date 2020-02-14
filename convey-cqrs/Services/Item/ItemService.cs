using System.Threading.Tasks;
using Convey.CQRS.Commands;
using convey_cqrs.Commands.Item;

namespace convey_cqrs.Services.Item
{
    public interface IItemService
    {
        Task CreateItemAsync(CreateItemCommand command);
    }

    public class ItemService : IItemService
    {
        private readonly ICommandDispatcher _dispatcher;

        public ItemService(ICommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public Task CreateItemAsync(CreateItemCommand command)
        {
            return _dispatcher.SendAsync(command);
        }
    }
}
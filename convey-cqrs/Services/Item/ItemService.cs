using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using convey_cqrs.Commands.Item;
using convey_cqrs.Models.Item;

namespace convey_cqrs.Services.Item
{
    public interface IItemService
    {
        Task CreateItemAsync(ItemPostDto command);
    }

    public class ItemService : IItemService
    {
        private readonly ICommandDispatcher _dispatcher;
        private readonly IItemCommandFactory _itemCommandFactory;

        public ItemService(ICommandDispatcher dispatcher, IItemCommandFactory itemCommandFactory)
        {
            _dispatcher = dispatcher;
            _itemCommandFactory = itemCommandFactory;
        }

        public Task CreateItemAsync(ItemPostDto command)
        {
            var createItemCommand = _itemCommandFactory.CreateInstance();
            createItemCommand.Description = command.Description;
            createItemCommand.Upc = command.Upc;
            
            return _dispatcher.SendAsync(createItemCommand);
        }
    }
}
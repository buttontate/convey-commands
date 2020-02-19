using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using convey_cqrs.Commands.Item;
using convey_cqrs.Data;
using convey_cqrs.Models.Item;

namespace convey_cqrs.Services.Item
{
    public interface IItemService
    {
        Task<Guid> CreateItemAsync(ItemPostDto item);
    }
    public class ItemService : IItemService
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IItemData _itemData;

        public ItemService(ICommandDispatcher commandDispatcher, IItemData itemData)
        {
            _commandDispatcher = commandDispatcher;
            _itemData = itemData;
        }

        public async Task<Guid> CreateItemAsync(ItemPostDto item)
        {
            var itemUuid = await _itemData.CreateItem(item);

            await DispatchCreateItem(item, itemUuid);

            return itemUuid;
        }

        private async Task DispatchCreateItem(ItemPostDto item, Guid itemUuid)
        {
            var createItemCommand = new CreateItemCommand()
            {
                Description = item.Description,
                Upc = item.Upc,
                Id = itemUuid
            };

            await _commandDispatcher.SendAsync(createItemCommand);
        }
    }
}
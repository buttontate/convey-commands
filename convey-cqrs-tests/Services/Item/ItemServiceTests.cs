using System;
using ChanceNET;
using Convey.CQRS.Commands;
using convey_cqrs.Commands.Item;
using convey_cqrs.Data;
using convey_cqrs.Models.Item;
using convey_cqrs.Services.Item;
using NSubstitute;
using Xunit;

namespace convey_cqrs_tests.Services.Item
{
    public class ItemServiceTests
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IItemData _itemData;
        private readonly ItemService _itemService;
        private readonly Chance _chance;

        public ItemServiceTests()
        {
            _chance = new Chance();
            _commandDispatcher = Substitute.For<ICommandDispatcher>();
            _itemData = Substitute.For<IItemData>();
            _itemService = new ItemService(_commandDispatcher, _itemData);
        }

        [Fact]
        public void CreateItemCallsDispatch()
        {
            var postItem = new ItemPostDto()
            {
                Description = _chance.Sentence(5),
                Upc = TestUtils.CreateUpc()
            };

            var createItemCommand = new CreateItemCommand()
            {
                Id = Guid.NewGuid(),
                Description = postItem.Description,
                Upc = postItem.Upc
            };
            _itemService.CreateItemAsync(postItem);
            _commandDispatcher.Received(1).SendAsync(createItemCommand);
        }
    }
}

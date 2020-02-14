using System;
using ChanceNET;
using Convey.CQRS.Commands;
using convey_cqrs.Commands.Item;
using convey_cqrs.Services.Item;
using NSubstitute;
using Xunit;

namespace convey_cqrs_tests.Services.Item
{
    public class ItemServiceTests
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ItemService _itemService;
        private readonly Chance _chance;

        public ItemServiceTests()
        {
            _chance = new Chance();
            _commandDispatcher = Substitute.For<ICommandDispatcher>();
            _itemService = new ItemService(_commandDispatcher);
        }

        [Fact]
        public void CreateItemCallsDispatch()
        {
            var createItemCommand = CreateItemCommand.CreateInstance();
            createItemCommand.Id = Guid.NewGuid();
            createItemCommand.Description = _chance.Sentence(5);
            createItemCommand.Upc = _chance.Long(100000000000, 999999999999).ToString();
            _itemService.CreateItemAsync(createItemCommand);
            _commandDispatcher.Received(1).SendAsync(createItemCommand);
        }
    }
}
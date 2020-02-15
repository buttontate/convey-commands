using ChanceNET;
using convey_cqrs.Controllers;
using convey_cqrs.Models.Item;
using convey_cqrs.Services.Item;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.Exceptions;
using Xunit;

namespace convey_cqrs_tests.Controllers
{
    public class ItemControllerTests
    {
        private readonly ItemsController _itemsController;
        private readonly IItemService _itemService;
        private readonly Chance _chance;
        
        public ItemControllerTests()
        {
            _chance = new Chance();
            _itemService = Substitute.For<IItemService>();
            _itemsController = new ItemsController(_itemService);
        }

        [Fact]
        public void GivenItem_ReturnsNewId()
        {
            var createdItem = new ItemPostDto()
            {
                Description = _chance.Sentence(5),
                Upc = TestUtils.CreateUpc()
            };

            var actionResult =  _itemsController.CreateItem(createdItem);
            var okObjectResult = actionResult as OkObjectResult;
            
            
        }
        
        [Fact]
        public void GivenItem_CallsItemService()
        {
            
        }

        [Fact]
        public void GivenInvaledModelState_ReturnsBadRequest()
        {
            
        }
    }
}
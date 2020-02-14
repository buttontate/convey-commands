using System;
using convey_cqrs.Commands.Item;
using convey_cqrs.Models.Item;
using convey_cqrs.Services.Item;
using Microsoft.AspNetCore.Mvc;

namespace convey_cqrs.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }
        
        [HttpPost]
        public IActionResult CreateItem(CreateItem item)
        {
            if (!ModelState.IsValid) return BadRequest();
            //TODO should move to factory rather than on concrete
            var createItemCommand = CreateItemCommand.CreateInstance(item);
            return Ok(_itemService.CreateItemAsync(createItemCommand));
        }
    }
}
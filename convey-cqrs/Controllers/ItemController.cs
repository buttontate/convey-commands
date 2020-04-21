using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> CreateItem(ItemPostDto item)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _itemService.CreateItemAsync(item));
        }
    }
}
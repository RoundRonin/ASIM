using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("storage/inventory")]
    public class InventoryController(IInventoryService inventoryService) : ControllerBase
    {
        [HttpGet("item/{itemId:guid}/itemInfo", Name = "GetItemInfoById")]
        public async Task<IActionResult> GetItemInfoById(Guid itemId)
        {
            var itemInfo = await inventoryService.GetItemInfoByIdAsync(itemId);
            if (itemInfo is null)
            {
                return NotFound();
            }
            return Ok(new { itemid = itemInfo.ItemId, details = itemInfo.Details });
        }
        
        [HttpGet(Name = "GetItemsByType")]
        public async Task<IActionResult> GetItemsByType([FromQuery] int? itemTypeId)
        {
            var items = await inventoryService.GetItemsByTypeAsync(itemTypeId);
            return Ok(items);
        }
        
        [HttpPost("item", Name = "AddNewItem")]
        public async Task<IActionResult> AddNewItem([FromBody] CreateInventoryItemDTO createInventoryItemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedItem = await inventoryService.AddNewItemAsync(createInventoryItemDTO);
            return Ok(new { itemid = addedItem.ItemId });
        }
        
        [HttpGet("item/{itemId:guid}", Name = "GetItemById")]
        public async Task<IActionResult> GetItemById(Guid itemId)
        {
            var item = await inventoryService.GetItemByIdAsync(itemId);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        
        // DELETE /storage/inventory/item/{itemId}
        [HttpDelete("item/{itemId:guid}", Name = "DeleteItem")]
        public async Task<IActionResult> DeleteItem(Guid itemId)
        {
            await inventoryService.DeleteItemAsync(itemId);
            return NoContent();
        }
    }
}

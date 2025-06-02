using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("storage/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        
        // GET /storage/inventory/item/{itemId}/itemInfo
        [HttpGet("item/{itemId:guid}/itemInfo", Name = "GetItemInfoById")]
        public async Task<IActionResult> GetItemInfoById(Guid itemId)
        {
            var itemInfo = await _inventoryService.GetItemInfoByIdAsync(itemId);
            if (itemInfo == null)
            {
                return NotFound();
            }
            return Ok(new { itemid = itemInfo.ItemId, details = itemInfo.Details });
        }
        
        // GET /storage/inventory?itemTypeId=...
        [HttpGet(Name = "GetItemsByType")]
        public async Task<IActionResult> GetItemsByType([FromQuery] int? itemTypeId)
        {
            var items = await _inventoryService.GetItemsByTypeAsync(itemTypeId);
            return Ok(items);
        }
        
        // POST /storage/inventory/item
        [HttpPost("item", Name = "AddNewItem")]
        public async Task<IActionResult> AddNewItem([FromBody] CreateInventoryItemDTO createInventoryItemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedItem = await _inventoryService.AddNewItemAsync(createInventoryItemDTO);
            return Ok(new { itemid = addedItem.ItemId });
        }
        
        // GET /storage/inventory/item/{itemId}
        [HttpGet("item/{itemId:guid}", Name = "GetItemById")]
        public async Task<IActionResult> GetItemById(Guid itemId)
        {
            var item = await _inventoryService.GetItemByIdAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        
        // DELETE /storage/inventory/item/{itemId}
        [HttpDelete("item/{itemId:guid}", Name = "DeleteItem")]
        public async Task<IActionResult> DeleteItem(Guid itemId)
        {
            await _inventoryService.DeleteItemAsync(itemId);
            return NoContent();
        }
    }
}

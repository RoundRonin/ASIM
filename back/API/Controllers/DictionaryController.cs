using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("dictionaries")]
public class DictionaryController(IDictionaryService dictionaryService) : ControllerBase
{
    [HttpGet("itemTypes")]
    public async Task<IActionResult> GetItemTypes() =>
        Ok(await dictionaryService.GetItemTypesAsync());

    [HttpGet("itemStatuses")]
    public async Task<IActionResult> GetItemStatuses() =>
        Ok(await dictionaryService.GetItemStatusesAsync());

    [HttpGet("repairStatuses")]
    public async Task<IActionResult> GetRepairStatuses() =>
        Ok(await dictionaryService.GetRepairStatusesAsync());

    [HttpGet("rentStatuses")]
    public async Task<IActionResult> GetRentStatuses() =>
        Ok(await dictionaryService.GetRentStatusesAsync());
}

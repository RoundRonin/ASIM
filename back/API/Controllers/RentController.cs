using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;

namespace API.Controllers;

[ApiController]
public class RentController(IRentService rentService) : ControllerBase
{
    [HttpPost("rent")]
    public async Task<IActionResult> NewRentCreate([FromBody] CreateRentDTO createRentDTO)
    {
        var rent = await rentService.CreateRentAsync(createRentDTO);
        return Ok(new { rentId = rent.RentId });
    }

    [HttpGet("rents")]
    public async Task<IActionResult> GetAllRents([FromQuery] string status)
    {
        var rents = await rentService.GetAllRentsAsync(status);
        return Ok(rents);
    }

    [HttpGet("rent/{rentId:int}")]
    public async Task<IActionResult> GetRentById(int rentId)
    {
        var rent = await rentService.GetRentByIdAsync(rentId);
        return Ok(rent);
    }

    [HttpPost("rent/{rentId:int}/status")]
    public async Task<IActionResult> SetRentStatus(int rentId, [FromBody] UpdateRentStatusDTO updateRentStatusDTO)
    {
        await rentService.SetRentStatusAsync(rentId, updateRentStatusDTO);
        return NoContent();
    }
}

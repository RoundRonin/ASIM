using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;

namespace API.Controllers;

[ApiController]
public class RepairController(IRepairService repairService) : ControllerBase
{
    [HttpGet("repairs", Name = "GetAllRepairs")]
    public async Task<IActionResult> GetAllRepairs([FromQuery] int? repairStatusId)
    {
        var repairs = await repairService.GetAllRepairsAsync(repairStatusId);
        return Ok(repairs);
    }
        
    [HttpGet("repair/{repairId:int}", Name = "GetRepair")]
    public async Task<IActionResult> GetRepair(int repairId)
    {
        var repair = await repairService.GetRepairByIdAsync(repairId);
        return Ok(repair);
    }
        
    [HttpPost("repair", Name = "NewRepairCreate")]
    public async Task<IActionResult> NewRepairCreate([FromBody] CreateRepairDTO createRepairDTO)
    {
        var repair = await repairService.CreateRepairAsync(createRepairDTO);
        return CreatedAtAction(nameof(GetRepair), new { repairId = repair.RepairId },
            new { repairId = repair.RepairId, estimatedEndDate = repair.EstimatedEndDate });
    }
        
    [HttpPost("repair/{repairId:int}/repairAccept", Name = "AcceptRepair")]
    public async Task<IActionResult> AcceptRepair(int repairId, [FromBody] AcceptRepairDTO acceptRepairDTO)
    {
        var repair = await repairService.AcceptRepairAsync(repairId, acceptRepairDTO);
        return Ok(repair);
    }
        
    [HttpPost("repair/{repairId:int}/repairClose", Name = "CloseRepair")]
    public async Task<IActionResult> CloseRepair(int repairId, [FromBody] CloseRepairDTO closeRepairDTO)
    {
        var repair = await repairService.CloseRepairAsync(repairId, closeRepairDTO);
        return Ok(repair);
    }
}
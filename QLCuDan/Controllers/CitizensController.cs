﻿using Microsoft.AspNetCore.Mvc;
using QLCuDan.BLL.Dto;



[Route("api/[controller]")]
[ApiController]
public class CitizensController : ControllerBase
{
    private readonly ICitizenService _citizenService;

    public CitizensController(ICitizenService citizenService)
    {
        _citizenService = citizenService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CitizenDto>>> GetCitizens()
    {
        var citizens = await _citizenService.GetAllCitizensAsync();
        return Ok(citizens);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CitizenDto>> GetCitizen(int id)
    {
        var citizen = await _citizenService.GetCitizenByIdAsync(id);
        if (citizen == null)
        {
            return NotFound();
        }
        return citizen;
    }

    [HttpPost]
    public async Task<ActionResult<CitizenDto>> PostCitizen(CitizenDto citizenDto)
    {
        var newCitizen = await _citizenService.CreateCitizenAsync(citizenDto);
        return CreatedAtAction(nameof(GetCitizen), new { id = newCitizen.CitizenId }, newCitizen);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCitizen(int id, CitizenDto citizenDto)
    {
        if (!await _citizenService.UpdateCitizenAsync(id, citizenDto))
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCitizen(int id)
    {
        if (!await _citizenService.DeleteCitizenAsync(id))
        {
            return NotFound();
        }
        return NoContent();
    }
}

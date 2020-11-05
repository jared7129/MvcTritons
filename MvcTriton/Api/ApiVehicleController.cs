using Microsoft.EntityFrameworkCore;
using MvcTriton.Models;
using Microsoft.AspNetCore.Mvc;
using MvcTriton.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq; 
using System.Net;  
using System.Net.Http;
using System;

[Route("api/[controller]")]
[ApiController]
public class ApiVehicleController : ControllerBase
{
    private readonly MvcTritonContext _context;

    public ApiVehicleController(MvcTritonContext context)
    {
        _context = context;
    }

    // GET: api/Games
    [HttpGet]
    public IEnumerable<Vehicle> GetVehicle()
    {
        return _context.Vehicle;
    }

    // GET: api/Branches/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehcile([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var vehicle = await _context.Vehicle.FindAsync(id);

        if (vehicle == null)
        {
            return NotFound();
        }

        return Ok(vehicle);
    }

    // PUT: api/Games/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBranch([FromRoute] int id, [FromBody] Vehicle vehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != vehicle.Id)
        {
            return BadRequest();
        }

        _context.Entry(vehicle).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (! VehicleExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool VehicleExists(int id)
    {
        throw new NotImplementedException();
    }

    // POST: api/Games
    [HttpPost]
    public async Task<IActionResult> PostVehicle([FromBody] Vehicle vehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Vehicle.Add(vehicle);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBranch", new { id = vehicle.Id }, vehicle);
    }

    // DELETE: api/Games/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehcile([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var vehicle = await _context.Vehicle.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicle.Remove(vehicle);
        await _context.SaveChangesAsync();

        return Ok(vehicle);
    }
}
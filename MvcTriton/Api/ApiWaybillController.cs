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
public class ApiWaybillController : ControllerBase
{
    private readonly MvcTritonContext _context;

    public ApiWaybillController(MvcTritonContext context)
    {
        _context = context;
    }

    // GET: api/Waybills
    [HttpGet]
    public IEnumerable<Waybill> GetWaybill()
    {
        return _context.Waybill;
    }

    // GET: api/Waybills/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWaybill([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var waybill = await _context.Waybill.FindAsync(id);

        if (waybill == null)
        {
            return NotFound();
        }

        return Ok(waybill);
    }

    // PUT: api/Waybills/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWaybill([FromRoute] int id, [FromBody] Waybill waybill)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != waybill.Id)
        {
            return BadRequest();
        }

        _context.Entry(waybill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (! WaybillExists(id))
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

    private bool WaybillExists(int id)
    {
        throw new NotImplementedException();
    }

    // POST: api/Games
    [HttpPost]
    public async Task<IActionResult> PostWaybill([FromBody] Waybill waybill)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Waybill.Add(waybill);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetWaybill", new { id = waybill.Id }, waybill);
    }

    // DELETE: api/Games/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWaybill([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var waybill = await _context.Waybill.FindAsync(id);
        if (waybill == null)
        {
            return NotFound();
        }

        _context.Waybill.Remove(waybill);
        await _context.SaveChangesAsync();

        return Ok(waybill);
    }
}
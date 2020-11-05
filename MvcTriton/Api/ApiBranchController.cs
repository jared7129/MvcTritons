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
public class ApiBranchController : ControllerBase
{
    private readonly MvcTritonContext _context;

    public ApiBranchController(MvcTritonContext context)
    {
        _context = context;
    }

    // GET: api/Games
    [HttpGet]
    public IEnumerable<Branch> GetBranch()
    {
        return _context.Movie;
    }

    // GET: api/Branches/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBranch([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var branch = await _context.Movie.FindAsync(id);

        if (branch == null)
        {
            return NotFound();
        }

        return Ok(branch);
    }

    // PUT: api/Games/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBranch([FromRoute] int id, [FromBody] Branch branch)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != branch.Id)
        {
            return BadRequest();
        }

        _context.Entry(branch).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (! BranchExists(id))
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

    private bool BranchExists(int id)
    {
        throw new NotImplementedException();
    }

    // POST: api/Games
    [HttpPost]
    public async Task<IActionResult> PostBranch([FromBody] Branch branch)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Movie.Add(branch);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBranch", new { id = branch.Id }, branch);
    }

    // DELETE: api/Games/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBranch([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var branch = await _context.Movie.FindAsync(id);
        if (branch == null)
        {
            return NotFound();
        }

        _context.Movie.Remove(branch);
        await _context.SaveChangesAsync();

        return Ok(branch);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalApp.Data;
using RentalApp.Models;

namespace RentalApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentersController : ControllerBase
    {
        private readonly RentalDataContext _context;

        public RentersController(RentalDataContext context)
        {
            _context = context;
        }

        // GET: api/Renters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Renter>>> GetRenters()
        {
            return await _context.Renters.ToListAsync();
        }

        // GET: api/Renters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Renter>> GetRenter(int id)
        {
            var renter = await _context.Renters.FindAsync(id);

            if (renter == null)
            {
                return NotFound();
            }

            return renter;
        }

        // PUT: api/Renters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRenter(int id, Renter renter)
        {
            if (id != renter.Id)
            {
                return BadRequest();
            }

            _context.Entry(renter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RenterExists(id))
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

        // POST: api/Renters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Renter>> PostRenter(Renter renter)
        {
            _context.Renters.Add(renter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRenter", new { id = renter.Id }, renter);
        }

        // DELETE: api/Renters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRenter(int id)
        {
            var renter = await _context.Renters.FindAsync(id);
            if (renter == null)
            {
                return NotFound();
            }

            _context.Renters.Remove(renter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RenterExists(int id)
        {
            return _context.Renters.Any(e => e.Id == id);
        }
    }
}

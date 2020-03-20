using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Educast.Models;

namespace Educast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandingController : ControllerBase
    {
        private readonly BrandingContext _context;

        public BrandingController(BrandingContext context)
        {
            _context = context;
        }

        // GET: api/Branding
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branding>>> GetBranding()
        {
            return await _context.Branding.ToListAsync();
        }

        // GET: api/Branding/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branding>> GetBranding(Guid id)
        {
            var brand = await _context.Branding.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        // PUT: api/Branding/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranding(Guid id, Branding brand)
        {
            if (id != brand.id)
            {
                return BadRequest();
            }

            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandingExists(id))
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

        // POST: api/Branding
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Branding>> PostBranding(Branding brand)
        {
            _context.Branding.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranding", new { id = brand.id }, brand);
        }

        // DELETE: api/Branding/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branding>> DeleteBranding(Guid id)
        {
            var brand = await _context.Branding.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Branding.Remove(brand);
            await _context.SaveChangesAsync();

            return brand;
        }

        private bool BrandingExists(Guid id)
        {
            return _context.Branding.Any(e => e.id == id);
        }
    }
}

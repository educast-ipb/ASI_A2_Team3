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
    public class SubtitleController : ControllerBase
    {
        private readonly SubtitleController _context;

        public SubtitleController(SubtitleController context)
        {
            _context = context;
        }

        // GET: api/Subtitle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subtitle>>> GetSubtitle()
        {
            return await _context.Subtitle.ToListAsync();
        }

        // GET: api/Subtitle/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Subtitle>> GetSubtitle(Guid id)
        {
            var sub = await _context.Subtitle.FindAsync(id);

            if (sub == null)
            {
                return NotFound();
            }

            return sub;
        }

        // PUT: api/Subtitle/
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubtitle(Guid id, Subtitle sub)
        {
            if (id != sub.id)
            {
                return BadRequest();
            }

            _context.Entry(sub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubtitleExists(id))
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

        // POST: api/Subtitle
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Subtitle>> PostSubtitle(Subtitle sub)
        {
            _context.Subtitle.Add(sub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubtitle", new { id = sub.id }, sub);
        }

        // DELETE: api/Subtitle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subtitle>> DeleteSubtitle(Guid id)
        {
            var sub = await _context.Subtitle.FindAsync(id);
            if (sub == null)
            {
                return NotFound();
            }

            _context.Subtitle.Remove(sub);
            await _context.SaveChangesAsync();

            return sub;
        }

        private bool SubtitleExists(Guid id)
        {
            return _context.Subtitle.Any(e => e.id == id);
        }
    }
}

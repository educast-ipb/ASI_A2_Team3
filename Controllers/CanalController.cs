using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Educast.Models;
using Educast.Data;

namespace Educast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanalController : ControllerBase
    {
        private readonly CanalContext _context;

        public CanalController(CanalContext context)
        {
            _context = context;
        }

        // GET: api/Canal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Canal>>> GetCanal()
        {
            return await _context.Canal.ToListAsync();
        }

        // GET: api/Canal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Canal>> GetCanal(Guid id)
        {
            var canal = await _context.Canal.FindAsync(id);

            if (canal == null)
            {
                return NotFound();
            }

            return canal;
        }

        // PUT: api/Canal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanal(Guid id, Canal canal)
        {
            if (id != canal.id)
            {
                return BadRequest();
            }

            _context.Entry(canal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanalExists(id))
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

        // POST: api/Canal
        [HttpPost]
        public async Task<ActionResult<Canal>> PostVideo(Canal canal)
        {
            _context.Canal.Add(canal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCanal", new { id = canal.id }, canal);
        }

        // DELETE: api/Canal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Canal>> DeleteCanal(Guid id)
        {
            var canal = await _context.Canal.FindAsync(id);
            if (canal == null)
            {
                return NotFound();
            }

            _context.Canal.Remove(canal);
            await _context.SaveChangesAsync();

            return canal;
        }

        private bool CanalExists(Guid id)
        {
            return _context.Canal.Any(e => e.id == id);
        }
    }
}

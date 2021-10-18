using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CakeBake.CakeBakeDir;

namespace CakeBake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeTablesController : ControllerBase
    {
        private readonly CakeBakeContext _context;

        public CakeTablesController(CakeBakeContext context)
        {
            _context = context;
        }

        // GET: api/CakeTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CakeTable>>> GetCakeTables()
        {
            return await _context.CakeTables.ToListAsync();
        }

        // GET: api/CakeTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CakeTable>> GetCakeTable(int id)
        {
            var cakeTable = await _context.CakeTables.FindAsync(id);

            if (cakeTable == null)
            {
                return NotFound();
            }

            return cakeTable;
        }

        // PUT: api/CakeTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCakeTable(int id, CakeTable cakeTable)
        {
            if (id != cakeTable.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(cakeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CakeTableExists(id))
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

        // POST: api/CakeTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CakeTable>> PostCakeTable(CakeTable cakeTable)
        {
            _context.CakeTables.Add(cakeTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CakeTableExists(cakeTable.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCakeTable", new { id = cakeTable.ProductId }, cakeTable);
        }

        // DELETE: api/CakeTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCakeTable(int id)
        {
            var cakeTable = await _context.CakeTables.FindAsync(id);
            if (cakeTable == null)
            {
                return NotFound();
            }

            _context.CakeTables.Remove(cakeTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CakeTableExists(int id)
        {
            return _context.CakeTables.Any(e => e.ProductId == id);
        }
    }
}

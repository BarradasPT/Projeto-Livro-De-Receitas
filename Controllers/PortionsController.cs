using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Livro_De_Receitas.Data;
using Projeto_Livro_De_Receitas.Models;

namespace Projeto_Livro_De_Receitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortionsController : ControllerBase
    {
        private readonly RecipeDbContext _context;

        public PortionsController(RecipeDbContext context)
        {
            _context = context;
        }

        // GET: api/Portions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portion>>> GetPortions()
        {
            return await _context.Portions.ToListAsync();
        }

        // GET: api/Portions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Portion>> GetPortion(int id)
        {
            var portion = await _context.Portions.FindAsync(id);

            if (portion == null)
            {
                return NotFound();
            }

            return portion;
        }

        // PUT: api/Portions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortion(int id, Portion portion)
        {
            if (id != portion.Id)
            {
                return BadRequest();
            }

            _context.Entry(portion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortionExists(id))
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

        // POST: api/Portions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Portion>> PostPortion(Portion portion)
        {
            _context.Portions.Add(portion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPortion", new { id = portion.Id }, portion);
        }

        // DELETE: api/Portions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortion(int id)
        {
            var portion = await _context.Portions.FindAsync(id);
            if (portion == null)
            {
                return NotFound();
            }

            _context.Portions.Remove(portion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PortionExists(int id)
        {
            return _context.Portions.Any(e => e.Id == id);
        }
    }
}

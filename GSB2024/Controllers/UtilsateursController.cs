using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSB2024.Models;

namespace GSB2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsateursController : ControllerBase
    {
        private readonly GSBContext _context;

        public UtilsateursController(GSBContext context)
        {
            _context = context;
        }

        // GET: api/Utilsateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilsateur>>> GetUtilsateurs()
        {
          if (_context.Utilsateurs == null)
          {
              return NotFound();
          }
            return await _context.Utilsateurs.ToListAsync();
        }

        // GET: api/Utilsateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilsateur>> GetUtilsateur(int id)
        {
          if (_context.Utilsateurs == null)
          {
              return NotFound();
          }
            var utilsateur = await _context.Utilsateurs.FindAsync(id);

            if (utilsateur == null)
            {
                return NotFound();
            }

            return utilsateur;
        }

        //// PUT: api/Utilsateurs/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUtilsateur(int id, Utilsateur utilsateur)
        //{
        //    if (id != utilsateur.IdUtilisateur)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(utilsateur).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UtilsateurExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Utilsateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilsateur>> PostUtilsateur(Utilsateur utilsateur)
        {
          if (_context.Utilsateurs == null)
          {
              return Problem("Entity set 'GSBContext.Utilsateurs'  is null.");
          }
            _context.Utilsateurs.Add(utilsateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilsateur", new { id = utilsateur.IdUtilisateur }, utilsateur);
        }

        // DELETE: api/Utilsateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilsateur(int id)
        {
            if (_context.Utilsateurs == null)
            {
                return NotFound();
            }
            var utilsateur = await _context.Utilsateurs.FindAsync(id);
            if (utilsateur == null)
            {
                return NotFound();
            }

            _context.Utilsateurs.Remove(utilsateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilsateurExists(int id)
        {
            return (_context.Utilsateurs?.Any(e => e.IdUtilisateur == id)).GetValueOrDefault();
        }
    }
}

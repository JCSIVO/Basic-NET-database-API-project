using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JCSIVODevWebApi.Data;
using JCSIVODevWebApi.Models;

namespace JCSIVODevWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly JCSIVODevWebApiContext _context;

        public PersonasController(JCSIVODevWebApiContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personas>>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personas>> GetPersonas(int id)
        {
            var personas = await _context.Personas.FindAsync(id);

            if (personas == null)
            {
                return NotFound();
            }

            return personas;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonas(int id, Personas personas)
        {
            if (id != personas.Id)
            {
                return BadRequest();
            }

            _context.Entry(personas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personas>> PostPersonas(Personas personas)
        {
            _context.Personas.Add(personas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas", new { id = personas.Id }, personas);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonas(int id)
        {
            var personas = await _context.Personas.FindAsync(id);
            if (personas == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(personas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonasExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCuDan.DAL.Data;
using QLCuDan.DAL.Model;

namespace QLCuDan.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenApartmentsController : ControllerBase
    {
        private readonly QLCuDanDALContext _context;

        public CitizenApartmentsController(QLCuDanDALContext context)
        {
            _context = context;
        }

        // GET: api/CitizenApartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitizenApartment>>> GetCitizenApartment()
        {
            return await _context.CitizenApartment.ToListAsync();
        }

        // GET: api/CitizenApartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitizenApartment>> GetCitizenApartment(int id)
        {
            var citizenApartment = await _context.CitizenApartment.FindAsync(id);

            if (citizenApartment == null)
            {
                return NotFound();
            }

            return citizenApartment;
        }

        // PUT: api/CitizenApartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitizenApartment(int id, CitizenApartment citizenApartment)
        {
            if (id != citizenApartment.Id)
            {
                return BadRequest();
            }

            _context.Entry(citizenApartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitizenApartmentExists(id))
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

        // POST: api/CitizenApartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CitizenApartment>> PostCitizenApartment(CitizenApartment citizenApartment)
        {
            _context.CitizenApartment.Add(citizenApartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitizenApartment", new { id = citizenApartment.Id }, citizenApartment);
        }

        // DELETE: api/CitizenApartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitizenApartment(int id)
        {
            var citizenApartment = await _context.CitizenApartment.FindAsync(id);
            if (citizenApartment == null)
            {
                return NotFound();
            }

            _context.CitizenApartment.Remove(citizenApartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitizenApartmentExists(int id)
        {
            return _context.CitizenApartment.Any(e => e.Id == id);
        }
    }
}

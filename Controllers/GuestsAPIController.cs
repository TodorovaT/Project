using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsAPIController : ControllerBase
    {
        private readonly ProjectContext _context;

        public GuestsAPIController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/GuestsAPI
        [HttpGet]
        public List<Guest> GetGuest(string firstnameguest, string lastnameguest)
        {
            //returns a filtered list of guests, by first and last name
            IQueryable<Guest> guests = _context.Guest.AsQueryable();
            if (!string.IsNullOrEmpty(firstnameguest))
            {
                guests = guests.Where(s => s.FirstName == firstnameguest);
            }
            if (!string.IsNullOrEmpty(lastnameguest))
            {
                guests = guests.Where(x => x.LastName == lastnameguest);
            }
            return guests.ToList();
        }

        // GET: api/GuestsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(int id)
        {
            var guest = await _context.Guest.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return guest;
        }

        // PUT: api/GuestsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuest(int id, Guest guest)
        {
            if (id != guest.Id)
            {
                return BadRequest();
            }

            _context.Entry(guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
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

        // POST: api/GuestsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Guest>> PostGuest(Guest guest)
        {
            _context.Guest.Add(guest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuest", new { id = guest.Id }, guest);
        }

        // DELETE: api/GuestsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guest>> DeleteGuest(int id)
        {
            var guest = await _context.Guest.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            _context.Guest.Remove(guest);
            await _context.SaveChangesAsync();

            return guest;
        }

        private bool GuestExists(int id)
        {
            return _context.Guest.Any(e => e.Id == id);
        }
    }
}

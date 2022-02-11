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
    public class WaitersAPIController : ControllerBase
    {
        private readonly ProjectContext _context;

        public WaitersAPIController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/WaitersAPI
        [HttpGet]
        public List<Waiter> GetWaiter(string firstname, string lastname)
        {
            //returns a filtered list of waiters, by first and last name
            IQueryable<Waiter> waiters = _context.Waiter.AsQueryable();
            if (!string.IsNullOrEmpty(firstname))
            {
                waiters = waiters.Where(s => s.FirstName == firstname);
            }
            if (!string.IsNullOrEmpty(lastname))
            {
                waiters = waiters.Where(x => x.LastName == lastname);
            }
            return waiters.ToList();
        }

        // PUT: api/WaitersAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaiter(int id, Waiter waiter)
        {
            if (id != waiter.Id)
            {
                return BadRequest();
            }

            _context.Entry(waiter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaiterExists(id))
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

        // POST: api/WaitersAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Waiter>> PostWaiter(Waiter waiter)
        {
            _context.Waiter.Add(waiter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaiter", new { id = waiter.Id }, waiter);
        }

        // DELETE: api/WaitersAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Waiter>> DeleteWaiter(int id)
        {
            var waiter = await _context.Waiter.FindAsync(id);
            if (waiter == null)
            {
                return NotFound();
            }

            _context.Waiter.Remove(waiter);
            await _context.SaveChangesAsync();

            return waiter;
        }

        private bool WaiterExists(int id)
        {
            return _context.Waiter.Any(e => e.Id == id);
        }
    }
}

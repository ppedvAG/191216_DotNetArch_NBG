using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using ppedv.TombstoneStrong.Data.EF;
using ppedv.TombstoneStrong.Domain;

namespace ppedv.TombstoneStrong.UI.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetsController : ControllerBase
    {
        private readonly EFContext _context;

        public TimeSheetsController(EFContext context)
        {
            _context = context;
        }

        // GET: api/TimeSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSheet>>> GetTimeSheet()
        {
            return await _context.TimeSheet.ToListAsync();
        }

        // GET: api/TimeSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheet>> GetTimeSheet(int id)
        {
            var timeSheet = await _context.TimeSheet.FindAsync(id);

            if (timeSheet == null)
            {
                return NotFound();
            }

            return timeSheet;
        }

        // PUT: api/TimeSheets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSheet(int id, TimeSheet timeSheet)
        {
            if (id != timeSheet.ID)
            {
                return BadRequest();
            }

            _context.Entry(timeSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSheetExists(id))
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

        // POST: api/TimeSheets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TimeSheet>> PostTimeSheet(TimeSheet timeSheet)
        {
            _context.TimeSheet.Add(timeSheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeSheet", new { id = timeSheet.ID }, timeSheet);
        }

        // DELETE: api/TimeSheets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeSheet>> DeleteTimeSheet(int id)
        {
            var timeSheet = await _context.TimeSheet.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            _context.TimeSheet.Remove(timeSheet);
            await _context.SaveChangesAsync();

            return timeSheet;
        }

        private bool TimeSheetExists(int id)
        {
            return _context.TimeSheet.Any(e => e.ID == id);
        }
    }
}

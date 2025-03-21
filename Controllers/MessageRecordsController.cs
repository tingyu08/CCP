using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A9223145_homework3.Models;

namespace A9223145_homework3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageRecordsController : ControllerBase
    {
        private readonly MessageBoardDbContext _context;

        public MessageRecordsController(MessageBoardDbContext context)
        {
            _context = context;
        }

        // GET: api/MessageRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageRecord>>> GetMessageRecords()
        {
          if (_context.MessageRecords == null)
          {
              return NotFound();
          }
            return await _context.MessageRecords.ToListAsync();
        }

        // GET: api/MessageRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageRecord>> GetMessageRecord(int id)
        {
          if (_context.MessageRecords == null)
          {
              return NotFound();
          }
            var messageRecord = await _context.MessageRecords.FindAsync(id);

            if (messageRecord == null)
            {
                return NotFound();
            }

            return messageRecord;
        }

        // POST: api/MessageRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<IActionResult> PutMessageRecord(int id, MessageRecord messageRecord)
        {
            if (id != messageRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(messageRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageRecordExists(id))
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

        // POST: api/MessageRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageRecord>> PostMessageRecord(MessageRecord messageRecord)
        {
          if (_context.MessageRecords == null)
          {
              return Problem("Entity set 'MessageBoardDbContext.MessageRecords'  is null.");
          }
            _context.MessageRecords.Add(messageRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageRecord", new { id = messageRecord.Id }, messageRecord);
        }

        // GET: api/MessageRecords/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteMessageRecord(int id)
        {
            if (_context.MessageRecords == null)
            {
                return NotFound();
            }
            var messageRecord = await _context.MessageRecords.FindAsync(id);
            if (messageRecord == null)
            {
                return NotFound();
            }

            _context.MessageRecords.Remove(messageRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageRecordExists(int id)
        {
            return (_context.MessageRecords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

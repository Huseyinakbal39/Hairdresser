using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hairdresser.Models;
using Hairdresser.Entities;

namespace Hairdresser.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class ServisController : ControllerBase
    {
        private readonly DbContext1 _context;

        public ServisController(DbContext1 context)
        {
            _context = context;
        }

        // GET: api/Servis
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var services = await _context.Services.ToListAsync();
            return Ok(services);
        }

        // GET: api/Servis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound(new { Message = "Service not found." });
            }

            return Ok(service);
        }

        // POST: api/Servis
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] Servis servis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Services.Add(servis);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceById), new { id = servis.Id }, servis);
        }

        // PUT: api/Servis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] Servis servis)
        {
            if (id != servis.Id)
            {
                return BadRequest(new { Message = "ID mismatch." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingService = await _context.Services.FindAsync(id);

            if (existingService == null)
            {
                return NotFound(new { Message = "Service not found." });
            }

            existingService.Name = servis.Name;
            existingService.Price = servis.Price;
            existingService.Gender = servis.Gender;

            _context.Entry(existingService).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Servis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound(new { Message = "Service not found." });
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

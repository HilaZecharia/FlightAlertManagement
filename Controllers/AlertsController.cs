using FlightAlertManagment.Data;
using FlightAlertManagment.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FlightAlertManagment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AlertsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/alerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alert>>> GetAlerts()
        {
            return await _context.Alerts.ToListAsync();
        }

        // POST: api/alerts
        [HttpPost]
        public async Task<ActionResult<Alert>> CreateAlert(Alert alert)
        {
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlert), new { id = alert.Id }, alert);
        }

        // GET: api/alerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alert>> GetAlert(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null)
                return NotFound();

            return alert;
        }


        // PUT: api/alerts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlert(int id, Alert alert)
        {
            if (id != alert.Id) 
                return BadRequest();

            _context.Entry(alert).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/alerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null) 
                return NotFound();

            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

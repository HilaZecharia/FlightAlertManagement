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
        private readonly ILogger<AlertsController> _logger;
        public AlertsController(AppDbContext context, ILogger<AlertsController> logger)
        {
            _context = context;
            _logger = logger;
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
            try
            {
                _context.Alerts.Add(alert);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAlert), new { id = alert.Id }, alert);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error creating alert");
                return StatusCode(500, "An error occurred while saving the alert to the database.");
            }
        }

        // GET: api/alerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alert>> GetAlert(int id)
        {
            try
            {
                var alert = await _context.Alerts.FindAsync(id);
                if (alert == null)
                    return NotFound();

                return alert;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving alert with ID {id}.");
                return StatusCode(500, "An unexpected error occurred while retrieving the alert.");
            }
        }


        // PUT: api/alerts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlert(int id, Alert alert)
        {
            try { 
            if (id != alert.Id)
                return BadRequest();

            _context.Entry(alert).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error update alert id :{id}");
                return StatusCode(500, $"An error occurred when try to update alert id {id}");
            }
        }

        // DELETE: api/alerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            try
            {
                var alert = await _context.Alerts.FindAsync(id);
                if (alert == null)
                    return NotFound();

                _context.Alerts.Remove(alert);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error delete alert id :{id}");
                return StatusCode(500, $"An error occurred when try to delete alert id {id}");
            }
          }
        }
    }


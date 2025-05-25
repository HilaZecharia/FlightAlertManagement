using FlightAlertManagment.Data;
using FlightAlertManagment.Model;
using FlightAlertManagment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FlightAlertManagment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {      
        private readonly ILogger<AlertsController> _logger;
        private readonly AlertService _alertService;

        public AlertsController(AlertService alertService, ILogger<AlertsController> logger)
        {
            _alertService = alertService;
            _logger = logger;
        }

        // GET: api/alerts
        [HttpGet]
        public async Task<IActionResult> GetAllAlerts() =>
            Ok(await _alertService.GetAllAlertsAsync());

        // POST: api/alerts
        [HttpPost]
        public async Task<ActionResult<Alert>> CreateAlert([FromBody] Alert alert)
        {
            try
            {
                var created = await _alertService.CreateAlertAsync(alert);
                return CreatedAtAction(nameof(GetAlert), new { id = created.Id }, created);
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
                var alert = await _alertService.GetAlertByIdAsync(id);
                if (alert == null) return NotFound();
                return Ok(alert);
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
            if (id != alert.Id)
                return BadRequest();

            try
            {
                var updated = await _alertService.UpdateAlertAsync(id, alert);
                if (!updated) 
                    return BadRequest();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error updating alert id: {id}");
                return StatusCode(500, $"An error occurred while updating alert id {id}");
            }
        }


        // DELETE: api/alerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            try
            {
                var deleted = await _alertService.DeleteAlertAsync(id);
                if (!deleted) 
                    return NotFound();

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


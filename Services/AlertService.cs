using FlightAlertManagment.Data;
using FlightAlertManagment.Model;
using Microsoft.EntityFrameworkCore;

namespace FlightAlertManagment.Services
{
    public class AlertService
    {
        private readonly AppDbContext _context;

        public AlertService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Alert>> GetAllAlertsAsync() => await _context.Alerts.ToListAsync();

        public async Task<Alert?> GetAlertByIdAsync(long id) => await _context.Alerts.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Alert> CreateAlertAsync(Alert alert)
        {
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
            return alert;
        }

        public async Task<bool> UpdateAlertAsync(long id, Alert alert)
        {
            if (id != alert.Id) return false;

            _context.Entry(alert).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAlertAsync(long id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null) return false;

            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

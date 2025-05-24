namespace FlightAlertManagment.Model
{
    public class Alert
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Flight FlightData { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}

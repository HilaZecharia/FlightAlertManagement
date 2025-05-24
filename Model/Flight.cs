namespace FlightAlertManagment.Model
{
    public enum Currency
    {
        Dollar,
        Euro,
        Israeli_Shekels
    }
    public class Flight
    {
        public int FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public Currency PriceCurrency { get; set; }
        public string DepartureAirPort { get; set; }
        public string ArrivalAirPort { get; set; }

    }
}

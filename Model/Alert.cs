namespace FlightAlertManagment.Model
{
    public enum Currency
    {
        USD,
        Euro,
        NIS
    }

    public class Alert
    {
        public long Id { get; set; }
        public string DepartureAirPort { get; set; }
        public string DestinationAirPort { get; set; }
        public DateTime TravelDate { get; set; }
        public decimal TargetPrice { get; set; }
        public Currency PriceCurrency { get; set; }
        public int UserId { get; set; }
    }
}

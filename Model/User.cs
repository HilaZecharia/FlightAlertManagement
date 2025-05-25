namespace FlightAlertManagment.Model
{
    public class User
    {
            public long UserID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public ICollection<Alert> Alerts { get; set; }

    }
}

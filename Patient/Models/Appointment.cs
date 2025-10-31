namespace PatientDashboardAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}

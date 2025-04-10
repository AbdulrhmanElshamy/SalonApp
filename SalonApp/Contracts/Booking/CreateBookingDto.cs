namespace SalonApp.Contracts.Booking
{
    public class CreateBookingDto
    {
        public Guid ServiceId { get; set; }
        public Guid SalonId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }

}

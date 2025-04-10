using SalonApp.Entities.consts.enums;

namespace SalonApp.Contracts.Booking
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid SalonId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public BookingStatus Status { get; set; }
    }

}

using SalonApp.Entities.consts.enums;

namespace SalonApp.Contracts.Booking
{
    public class UpdateBookingDto
    {
        public Guid ServiceId { get; set; }
        public Guid SalonId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }

}

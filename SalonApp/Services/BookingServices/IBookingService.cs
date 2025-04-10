using SalonApp.Abstractions;
using SalonApp.Contracts.Booking;
using SalonApp.Contracts.Common;

namespace SalonApp.Services.BookingServices
{
    public interface IBookingService
    {
        Task<PaginatedList<BookingDto>> GetAllAsync(RequestFilters request);
        Task<Result<BookingDto>> GetByIdAsync(Guid id);
        Task<Result<BookingDto>> CreateAsync(CreateBookingDto dto);
        Task<Result> UpdateAsync(UpdateBookingDto dto,Guid Id);
        Task<Result> ConfirmBooking(Guid id);
        Task<Result> CancelBooking(Guid id);
    }
}

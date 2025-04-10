using Mapster;
using Microsoft.EntityFrameworkCore;
using SalonApp.Abstractions;
using SalonApp.Contracts.Booking;
using SalonApp.Contracts.Common;
using SalonApp.Entities;
using SalonApp.Extensions;
using SalonApp.Persistence;
using System.Threading;
using System.Linq.Dynamic.Core;

namespace SalonApp.Services.BookingServices
{
    public class BookingService(ApplicationDbContext dbContext,IHttpContextAccessor httpContextAccessor) : IBookingService
    {


        public async Task<PaginatedList<BookingDto>> GetAllAsync(RequestFilters request)
        {
            var query =  dbContext.Bookings.AsQueryable();


            if (!string.IsNullOrEmpty(request.SortColumn))
            {
                query = query.OrderBy($"{request.SortColumn} {request.SortDirection}");
            }

            var source = query
                            .ProjectToType<BookingDto>()
            .AsNoTracking();


            var bookings = await PaginatedList<BookingDto>.CreateAsync(source, request.PageNumber, request.PageSize);


            return bookings;

        }

        public async Task<Result<BookingDto>> GetByIdAsync(Guid id)
        {
            var booking = await dbContext.Bookings.FindAsync(id);

            if (booking is null)
                return Result.Failure<BookingDto>(Error.None);

            return Result.Success(booking.Adapt<BookingDto>());
        }

        public async Task<Result<BookingDto>> CreateAsync(CreateBookingDto dto)
        {
            var booking = dto.Adapt<Booking>();

            booking.UserId = httpContextAccessor.HttpContext!.User.GetUserId()!;



            var serviceSalone = await dbContext.SalonServices.FirstOrDefaultAsync(c => c.ServiceId == dto.ServiceId && c.SalonId == dto.SalonId && c.IsAvailable);

            if(serviceSalone is null) 
                return Result.Failure<BookingDto>(Error.None);

            booking.Price = serviceSalone.Price;
            
            await dbContext.AddAsync(booking);

            await dbContext.SaveChangesAsync();

            return Result.Success(booking.Adapt<BookingDto>());

        }




        public async Task<Result> UpdateAsync(UpdateBookingDto dto,Guid Id)
        {
            var booking = await dbContext.Bookings.FindAsync(Id);

            if(booking is null)
                return Result.Failure(Error.None);

            if (booking.Status == Entities.consts.enums.BookingStatus.Cancelled || booking.Status == Entities.consts.enums.BookingStatus.Completed)
                return Result.Failure(Error.None);


            var serviceSalone = await dbContext.SalonServices.FirstOrDefaultAsync(c => c.ServiceId == dto.ServiceId && c.SalonId == dto.SalonId && c.IsAvailable);

            if (serviceSalone is null)
                return Result.Failure<BookingDto>(Error.None);


            booking.SalonId = serviceSalone.SalonId;
            booking.ServiceId = serviceSalone.ServiceId;

            booking.Price = serviceSalone.Price;

            booking.AppointmentDate = dto.AppointmentDate;

            dbContext.Update(booking);

            await dbContext.SaveChangesAsync();

            return Result.Success();


        }


        public async Task<Result> CancelBooking(Guid id)
        {
            var booking = await dbContext.Bookings.FindAsync(id);

            if (booking is null)
                return Result.Failure<BookingDto>(Error.None);

            if (booking.Status == Entities.consts.enums.BookingStatus.Completed)
                return Result.Failure(Error.None);

            booking.Status = Entities.consts.enums.BookingStatus.Cancelled;

            dbContext.Update(booking);

            await dbContext.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result> ConfirmBooking(Guid id)
        {
            var booking = await dbContext.Bookings.FindAsync(id);

            if (booking is null)
                return Result.Failure<BookingDto>(Error.None);

            if (booking.Status == Entities.consts.enums.BookingStatus.Completed)
                return Result.Failure(Error.None);

            booking.Status = Entities.consts.enums.BookingStatus.Confirmed;

            dbContext.Update(booking);

            await dbContext.SaveChangesAsync();

            return Result.Success();
        }



    }
}

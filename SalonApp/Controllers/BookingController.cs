using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SalonApp.Abstractions;
using SalonApp.Contracts.Booking;
using SalonApp.Contracts.Common;
using SalonApp.Services.BookingServices;

namespace SalonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController(IBookingService service) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get(RequestFilters filters)
        {
            return Ok(await service.GetAllAsync(filters));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await service.GetByIdAsync(id);

            return res.IsSuccess?
                Ok(res) 
                : res.ToProblem();
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateBookingDto request)
        {
            var res = await service.CreateAsync(request);

            return res.IsSuccess ? CreatedAtAction(nameof(Get), new { res.Value.Id }, res.Value) : res.ToProblem();
        }


        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(Guid id,UpdateBookingDto request)
        {
            var res = await service.UpdateAsync(request,id);

            return res.IsSuccess ? NoContent() : res.ToProblem();
        }

        [HttpPost("Confirm/{id}")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            var res = await service.ConfirmBooking(id);

            return res.IsSuccess ? NoContent() : res.ToProblem();
        }

        [HttpPost("Cancel/{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var res = await service.CancelBooking(id);

            return res.IsSuccess ? NoContent() : res.ToProblem();
        }
    }
}

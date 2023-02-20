using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBookingAPI.Models;
using HotelBookingAPI.Data;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueHotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;
        public ValueHotelBookingController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit

        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if(booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);
                if(bookingInDb==null)
                {
                    return new JsonResult(NotFound());
                }

                bookingInDb = booking;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(booking));
        }

    }
}

using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var staffCount = _staffService.TGetStaffCount();
            return Ok(staffCount);
        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var bookingCount = _bookingService.TGetBookingCount();
            return Ok(bookingCount);
        }

        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            var appUserCount = _appUserService.TAppUserCount();
            return Ok(appUserCount);
        }

        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var roomCount = _roomService.TRoomCount();
            return Ok(roomCount);
        }
    }
}

using LocalBookings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingsApi.Controllers.BookingServiceController
{
    [ApiController]
    [Route("[controller]")]
    public class GetAvailableRoomsController : ControllerBase
    {
        private readonly ILogger<GetAvailableRoomsController> _logger;

        public GetAvailableRoomsController(ILogger<GetAvailableRoomsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<AvailableSlot> Get(DateTime dayStart, DateTime dayEnd, double duration, Room[] room)
        {
            var results = new List<AvailableSlot>()
            {
                new()
                {
                    StartTime = DateTime.Now,
                    EndTime = DateTime.UtcNow
                }

            };

            return results;
        }
    }
}

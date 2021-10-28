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
    public class GetAvailableSlotsForPeopleAndRoomController
    {
        private readonly ILogger<GetAvailableSlotsForPeopleAndRoomController> _logger;

        public GetAvailableSlotsForPeopleAndRoomController(ILogger<GetAvailableSlotsForPeopleAndRoomController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        AvailableSlot[] Get()
        {
            var results = new AvailableSlot[]
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

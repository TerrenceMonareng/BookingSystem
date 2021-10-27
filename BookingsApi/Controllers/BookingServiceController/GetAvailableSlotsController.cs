using LocalBookings.Models;
using MediatR;
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
    public class GetAvailableSlotsController : ControllerBase
    {
        private readonly ILogger<GetAvailableSlotsController> _logger;

        public GetAvailableSlotsController(ILogger<GetAvailableSlotsController> logger)
        {
            _logger = logger;
        }

 
        [HttpGet]
        public IEnumerable<AvailableSlot> Get(DateTime dayStart, DateTime dayEnd, double duration, Person[] required)
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

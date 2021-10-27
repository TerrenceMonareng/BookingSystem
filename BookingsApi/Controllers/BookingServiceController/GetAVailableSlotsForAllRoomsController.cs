using LocalBookings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BookingsApi.Controllers.BookingServiceController
{
    [ApiController]
    [Route("[controller]")]
    public class GetAVailableSlotsForAllRoomsController : ControllerBase
    {
        private readonly ILogger<GetAVailableSlotsForAllRoomsController> _logger;

        private readonly string Email = "Agile";


        public GetAVailableSlotsForAllRoomsController(ILogger<GetAVailableSlotsForAllRoomsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<FinalAvailableSlots[]> Get(double duration)
        {

            var availableRoomsList1 = new List<FinalAvailableSlots[]>();

            var results = new FinalAvailableSlots[]
            {

                new()
                {

                     Email = Email,
                     AvailableSlots = new AvailableSlot[]
                     {
                         new()
                         {
                             StartTime = DateTime.Now,
                             EndTime = DateTime.UtcNow
                         }
                     }
                }
                    
            };
            availableRoomsList1.Add(results);

            return availableRoomsList1;
        }
    }
}

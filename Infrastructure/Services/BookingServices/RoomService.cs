using Infrastructure.Services.Interfarces;
using Infrastructure.Services.Interfarces.BookingService;
using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.BookingServices
{
   public class RoomService : IRoomsService
    {
        private readonly ICalendarService _calendar;

        public RoomService(ICalendarService calendar)
        {
            _calendar = calendar;
        }

        public IEnumerable<AvailableSlot> CalculateAvailableRooms(int duration, Room[] room)
        {
            DateTime dayStart = DateTime.MinValue;
            DateTime dayEnd = DateTime.MinValue;
            
            var availableSlots = _calendar.GetAvailableSlots(dayStart, dayEnd, room);

            return _calendar.CalculateAvailability(availableSlots, duration);
        }

    }
}

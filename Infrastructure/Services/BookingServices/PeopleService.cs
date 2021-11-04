using Infrastructure.Services.Interfarces.BookingService;
using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.BookingServices
{
    public class PeopleService : IPeopleService
    {
        private readonly ICalendarService _calendar;

        public PeopleService(ICalendarService calendar)
        {
            _calendar = calendar;
        }

        public IEnumerable<AvailableSlot> CalculateAvailableSlots(Person organiser, Person[] required, int duration)
        {
            DateTime DayStart = DateTime.MinValue;
            DateTime DayEnd = DateTime.MinValue;
            var futureSlots = new List<AvailableSlot>();

            var availableSlots = _calendar.GetAvailableSlots(DayStart, DayEnd, required.Union(new[] { organiser }).ToArray());

            return _calendar.CalculateAvailability(availableSlots, duration);

        }

    }
}

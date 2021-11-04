using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.BookingService
{
    public interface ICalendarService
    {
        /// <summary>
        /// This function get the available slots of people from the calendar
        /// </summary>
        /// <param name="dayStart"></param>
        /// <param name="dayEnd"></param>
        /// <param name="required"></param>
        /// <returns></returns>
        IEnumerable<AvailableSlot> GetAvailableSlots<T>(DateTime dayStart, DateTime dayEnd, T[] required)
            where T : Calendar;

        IEnumerable<AvailableSlot> CalculateAvailability(IEnumerable<AvailableSlot> availableSlots, int duration);
    }
}

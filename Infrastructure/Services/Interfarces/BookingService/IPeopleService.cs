using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.BookingService
{
    public interface IPeopleService
    {
        /// <summary>
        /// This function get the available slots of people from the calendar
        /// </summary>
        /// <param name="dayStart"></param>
        /// <param name="dayEnd"></param>
        /// <param name="required"></param>
        /// <returns></returns>
        IEnumerable<AvailableSlot> GetAvailableSlots(DateTime dayStart, DateTime dayEnd, Person[] required);

        /// <summary>
        /// This function calculate and retrieve the available slots for people
        /// </summary>
        /// <param name="organiser"></param>
        /// <param name="required"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        AvailableSlot[] CalculateAvailableSlots(Person organiser, Person[] required, double duration);

    }
}

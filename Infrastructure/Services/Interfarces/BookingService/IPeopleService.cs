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
        /// This function calculate and retrieve the available slots for people
        /// </summary>
        /// <param name="organiser"></param>
        /// <param name="required"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        IEnumerable<AvailableSlot> CalculateAvailableSlots(Person organiser, Person[] required, int duration);
    }
}

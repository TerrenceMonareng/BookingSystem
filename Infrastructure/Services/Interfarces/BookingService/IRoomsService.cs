using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.BookingService
{
   public interface IRoomsService
    {
        /// <summary>
        /// This function get the available slots of rooms from the calendar
        /// </summary>
        /// <param name="dayStart"></param>
        /// <param name="dayEnd"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        IEnumerable<AvailableSlot> GetRoomAvailableSlots(DateTime dayStart, DateTime dayEnd, Room[] room);

        /// <summary>
        /// This function calculate and retrieve the available slots for rooms
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        AvailableSlot[] CalculateAvailableRooms(double duration, Room[] room);

    }
}

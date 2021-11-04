using LocalBookings.Models;
using System.Collections.Generic;

namespace Infrastructure.Services.Interfarces.BookingService
{
    public interface IRoomsService
    {
        /// <summary>
        /// This function calculate and retrieve the available slots for rooms
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        IEnumerable<AvailableSlot> CalculateAvailableRooms(int duration, Room[] room);

    }
}

using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.BookingService
{
   public interface IRoomService
    {

        IEnumerable<AvailableSlot> GetRoomAvailableSlots(DateTime dayStart, DateTime dayEnd, Room[] room);

        AvailableSlot[] CalculateAvailableRooms(double duration, Room[] room);

    }
}

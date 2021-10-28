using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.CalendarServices
{
   public interface IRoomsCalendar
    {
        Room FindRoom(string roomName);
        public List<Room> GetRooms();
    }
}

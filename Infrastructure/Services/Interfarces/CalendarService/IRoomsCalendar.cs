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
        /// <summary>
        /// This function find a room from the caledar 
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        Room FindRoom(string roomName);

        /// <summary>
        /// This function retrieves all the rooms from the calendar
        /// </summary>
        /// <returns></returns>
        public List<Room> GetRooms();
    }
}

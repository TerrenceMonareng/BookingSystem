using Infrastructure.Services.BookingServices;
using Infrastructure.Services.CalendarServices;
using Infrastructure.Services.Interfarces.BookingService;
using Infrastructure.Services.Interfarces.CalendarServices;


namespace LocalBookings
{
    public static class Factory
    {
        /// <summary>
        /// This interface is to get a room service
        /// </summary>
        /// <returns></returns>
        public static IRoomsService CreateRoomService()
        {
            return new RoomService();
        }

        /// <summary>
        /// This interface is used to retrieve all the people servies
        /// </summary>
        /// <returns></returns>
        public static IPeopleService CreatePersonService()
        {
            return new PeopleService();
        }
        
        /// <summary>
        /// This interface it retrieves the services for people and rooms available
        /// </summary>
        /// <returns></returns>
        public static IPeopleAndRoomsService CreatePeopleAndRoomService()
        {
            return new PeopleAndRomsService(CreateRoomService());
        }

        /// <summary>
        /// This interface the people calendar
        /// </summary>
        /// <returns></returns>
        public static IPeopleCalendar CreatePeopleCalendar()
        {
            return new PeopleCalender();
        }

        /// <summary>
        /// This interface retrieves the calender for rooms 
        /// </summary>
        /// <returns></returns>
        public static IRoomsCalendar CreateRoomsCalendar()
        {
            return new RoomsCalendar();
        }

    }
}

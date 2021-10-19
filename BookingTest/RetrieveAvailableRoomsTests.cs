//using LocalBookings.Models;
//using LocalBookings.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace BookingTest
//{
//   public class RetrieveAvailableRoomsTests
//    {
//        [Fact]
//        public void Available_Slots_For_Agile_Test()
//        {
//            // Arrange

//            var booking = new BookingService();
//            var calenderService = new CalendarService();
//            var room = new Room();

//            room.Email = "Agile";

//            room = calenderService.FindRoom(room.Email);


//            double duration = 61;

//            var listOfRooms = new List<Room>();

//            var Rooms = calenderService.GetRooms();

//            listOfRooms.Add(room);

//            var availableSlots = booking.CalculateAvailableRooms(duration, Rooms.ToArray());


//            // Act

//            var results = booking.RetrieveAvailableRooms(Rooms, availableSlots,duration);

//            // Assert

//            Assert.NotNull(results);
//            Assert.Collection(results,
//               slot =>
//               {
//                   Assert.Equal("Cloud", slot);
//               },
//               slot =>
//               {
//                   Assert.Equal("Nexus", slot);
//               });
//        }

//    }
//}

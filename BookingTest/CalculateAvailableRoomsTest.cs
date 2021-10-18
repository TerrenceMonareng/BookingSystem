using LocalBookings.Models;
using LocalBookings.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingTest
{
    public class CalculateAvailableRoomsTest
    {
        [Fact]
        public void Available_Slots_For_Agile_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var room = new Room();

            room.Email = "Agile";

            room = calenderService.FindRoom(room.Email);
            
          
            double duration = 61;

            var listOfRooms = new List<Room>();

            listOfRooms.Add(room);
            
          

            // Act

            var results = booking.CalculateAvailableRooms(duration, listOfRooms.ToArray());

            // Assert

            Assert.NotNull(results);
            Assert.Equal(0, results.Length);
        }

        [Fact]
        public void Available_Slots_For_Cloud_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var room = new Room();

            room.Email = "Cloud";

            room = calenderService.FindRoom(room.Email);


            double duration = 61;

            var listOfRooms = new List<Room>();

            listOfRooms.Add(room);



            // Act

            var results = booking.CalculateAvailableRooms(Convert.ToDouble(duration), listOfRooms.ToArray());

            // Assert

            Assert.NotNull(results);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 22, 09, 00, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 11, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 22, 11, 45, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 13, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 22, 13, 30, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 23, 08, 00, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 24, 08, 00, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot.EndTime);
               });

        }

        [Fact]
        public void Available_Slots_For_Nexus_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var room = new Room();

            room.Email = "Nexus";

            room = calenderService.FindRoom(room.Email);


            double duration = 61;

            var listOfRooms = new List<Room>();

            listOfRooms.Add(room);



            // Act

            var results = booking.CalculateAvailableRooms(Convert.ToDouble(duration), listOfRooms.ToArray());

            // Assert

            Assert.NotNull(results);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 22, 08, 00, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 10, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 22, 14, 30, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 23, 08, 00, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 24, 08, 00, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 25, 08, 00, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 25, 17, 00, 00), slot.EndTime);
               });

        }
    }
}

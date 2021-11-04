using Infrastructure.Services.Interfarces.BookingService;
using Infrastructure.Services.Interfarces.CalendarServices;
using LocalBookings;
using LocalBookings.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace BookingTest
{
    public class CalculateAvailableRoomsTest
    {
        IRoomsService roomService = Factory.CreateRoomService();
        IRoomsCalendar roomsCalendar = Factory.CreateRoomsCalendar();



        [Fact]
        public void Available_Slots_For_Agile_Test()
        {
            // Arrange

            var room = new Room();

            room.Email = "Agile";

            room = roomsCalendar.FindRoom(room.Email);


            int duration = 61;

            var listOfRooms = new List<Room>();

            listOfRooms.Add(room);



            // Act

            var results = roomService.CalculateAvailableRooms(duration, listOfRooms.ToArray());

            // Assert

            Assert.NotNull(results);
            Assert.Collection(results,
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 22, 10, 00, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 22, 15, 00, 00), slot.EndTime);
                },
                 slot =>
                 {
                     Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot.StartTime);
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

        [Fact]
        public void Available_Slots_For_Cloud_Test()
        {
            // Arrange

            var room = new Room();

            room.Email = "Cloud";

            room = roomsCalendar.FindRoom(room.Email);


            int duration = 61;

            var listOfRooms = new List<Room>();

            listOfRooms.Add(room);



            // Act

            var results = roomService.CalculateAvailableRooms(duration, listOfRooms.ToArray());

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

            var room = new Room();

            room.Email = "Nexus";

            room = roomsCalendar.FindRoom(room.Email);


            int duration = 61;

            var listOfRooms = new List<Room>();

            listOfRooms.Add(room);



            // Act

            var results = roomService.CalculateAvailableRooms(duration, listOfRooms.ToArray());

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

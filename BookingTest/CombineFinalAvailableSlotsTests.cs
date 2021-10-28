using LocalBookings.Models;
using LocalBookings.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookingTest
{
    public class CombineFinalAvailableSlotsTests
    {
        [Fact]
        public void Available_Slots_For_Agile_And_Three_People_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var person = new Person();
            person.Email = "Amanda";

            List<Person> listOfNames = new List<Person>()
            {
               new()
               {
                   Email = "Terrence"
               },
               new()
               {
                   Email = "Hans"
               },
               new()
               {
                   Email = "Amanda"
               }
            };

            person = calenderService.FindPerson(person.Email);
            var people = calenderService.FindPeople(listOfNames.ToArray());



            var rooms = calenderService.GetRooms();


            double duration = 61;

            var listOfRooms = new List<Room>();


            var availableSlots = booking.CalculateAvailableSlots(person, people.ToArray(), Convert.ToDouble(duration));

            var availableRoomSlots = booking.GetAVailableSlotsForAllRooms(rooms, availableSlots, duration);


            // Act

            var results = booking.CombineFinalAvailableSlots(availableRoomSlots);

            // Assert

            Assert.NotNull(results);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal("Agile, Cloud, Nexus", slot.Email[0]);
                   Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot.StartTime[0]);
                   Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot.EndTime[0]);

                   Assert.Equal("Agile, Cloud, Nexus", slot.Email[1]);
                   Assert.Equal(new DateTime(2021, 09, 23, 15, 30, 00), slot.StartTime[1]);
                   Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot.EndTime[1]);

                   Assert.Equal("Agile, Cloud, Nexus", slot.Email[2]);
                   Assert.Equal(new DateTime(2021, 09, 24, 15, 30, 00), slot.StartTime[2]);
                   Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot.EndTime[2]);

                   Assert.Equal("Agile, Nexus", slot.Email[3]);
                   Assert.Equal(new DateTime(2021, 09, 25, 08, 00, 00), slot.StartTime[3]);
                   Assert.Equal(new DateTime(2021, 09, 25, 17, 00, 00), slot.EndTime[3]);

               });

        }

        [Fact]
        public void Available_Slots_For_Agile_And_Two_People_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var person = new Person();
            person.Email = "Terrence";

            List<Person> listOfNames = new List<Person>()
            {
               new()
               {
                   Email = "Terrence"
               },
               new()
               {
                   Email = "Hans"
               }
            };

            person = calenderService.FindPerson(person.Email);
            var people = calenderService.FindPeople(listOfNames.ToArray());



            var rooms = calenderService.GetRooms();


            double duration = 61;

            var listOfRooms = new List<Room>();


            var availableSlots = booking.CalculateAvailableSlots(person, people.ToArray(), Convert.ToDouble(duration));

            var availableRoomSlots = booking.GetAVailableSlotsForAllRooms(rooms, availableSlots, duration);


            // Act

            var results = booking.CombineFinalAvailableSlots(availableRoomSlots);

            // Assert

            Assert.NotNull(results);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal("Agile, Cloud", slot.Email[0]);
                   Assert.Equal(new DateTime(2021, 09, 22, 11, 45, 00), slot.StartTime[0]);
                   Assert.Equal(new DateTime(2021, 09, 22, 13, 00, 00), slot.EndTime[0]);

                   Assert.Equal("Agile, Cloud", slot.Email[1]);
                   Assert.Equal(new DateTime(2021, 09, 22, 13, 30, 00), slot.StartTime[1]);
                   Assert.Equal(new DateTime(2021, 09, 22, 15, 00, 00), slot.EndTime[1]);

                   Assert.Equal("Agile, Cloud, Nexus", slot.Email[2]);
                   Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot.StartTime[2]);
                   Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot.EndTime[2]);

                   Assert.Equal("Agile, Cloud, Nexus", slot.Email[3]);
                   Assert.Equal(new DateTime(2021, 09, 23, 11, 45, 00), slot.StartTime[3]);
                   Assert.Equal(new DateTime(2021, 09, 23, 13, 00, 00), slot.EndTime[3]);

                   Assert.Equal("Agile, Cloud, Nexus", slot.Email[4]);
                   Assert.Equal(new DateTime(2021, 09, 23, 13, 30, 00), slot.StartTime[4]);
                   Assert.Equal(new DateTime(2021, 09, 23, 15, 00, 00), slot.EndTime[4]);

                   Assert.Equal("Nexus", slot.Email[5]);
                   Assert.Equal(new DateTime(2021, 09, 22, 14, 30, 00), slot.StartTime[5]);
                   Assert.Equal(new DateTime(2021, 09, 22, 15, 00, 00), slot.EndTime[5]);

               });

        }

     
    }
}

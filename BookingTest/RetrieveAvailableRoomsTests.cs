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
    public class RetrieveAvailableRoomsTests
    {
        [Fact]
        public void Available_Slots_For_Agile_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var room = new Room();
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

            room.Email = "Agile";

            room = calenderService.FindRoom(room.Email);


            double duration = 61;

            var listOfRooms = new List<Room>();

            listOfRooms.Add(room);


            var availableSlots = booking.CalculateAvailableSlots(person, people.ToArray(), Convert.ToDouble(duration));


            // Act

            var results = booking.GetAVailableSlotsForAllRooms(listOfRooms, availableSlots, duration);

            // Assert

            Assert.NotNull(results);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal("Agile", slot[0].Email);
                   Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot[0].AvailableSlots[0].StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
               },
               slot =>
               {
                   Assert.Equal("Agile", slot[0].Email);
                   Assert.Equal(new DateTime(2021, 09, 23, 15, 30, 00), slot[0].AvailableSlots[0].StartTime);
                   Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
               },
               slot =>
               {
                   Assert.Equal("Agile", slot[0].Email);
                   Assert.Equal(new DateTime(2021, 09, 24, 15, 30, 00), slot[0].AvailableSlots[0].StartTime);
                   Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
               },
                slot =>
                {
                    Assert.Equal("Agile", slot[0].Email);
                    Assert.Equal(new DateTime(2021, 09, 25, 08, 00, 00), slot[0].AvailableSlots[0].StartTime);
                    Assert.Equal(new DateTime(2021, 09, 25, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
                });
        }

        [Fact]
        public void Available_Slots_For_Cloud_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var room = new Room();
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

            room.Email = "Cloud";

            room = calenderService.FindRoom(room.Email);


            double duration = 61;

            var listOfRooms = new List<Room>();

            listOfRooms.Add(room);


            var availableSlots = booking.CalculateAvailableSlots(person, people.ToArray(), Convert.ToDouble(duration));


            // Act

            var results = booking.GetAVailableSlotsForAllRooms(listOfRooms, availableSlots, duration);

            // Assert

            Assert.NotNull(results);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal("Cloud", slot[0].Email);
                   Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot[0].AvailableSlots[0].StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
               },
               slot =>
               {
                   Assert.Equal("Cloud", slot[0].Email);
                   Assert.Equal(new DateTime(2021, 09, 23, 15, 30, 00), slot[0].AvailableSlots[0].StartTime);
                   Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
               },
               slot =>
               {
                   Assert.Equal("Cloud", slot[0].Email);
                   Assert.Equal(new DateTime(2021, 09, 24, 15, 30, 00), slot[0].AvailableSlots[0].StartTime);
                   Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
               });
        }

        [Fact]
        public void Available_Slots_For_Nexus_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var room = new Room();
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

            room.Email = "Nexus";

            room = calenderService.FindRoom(room.Email);


            double duration = 61;

            var listOfRooms = new List<Room>();

            listOfRooms.Add(room);


            var availableSlots = booking.CalculateAvailableSlots(person, people.ToArray(), Convert.ToDouble(duration));


            // Act

            var results = booking.GetAVailableSlotsForAllRooms(listOfRooms, availableSlots, duration);

            // Assert

            Assert.NotNull(results);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal("Nexus", slot[0].Email);
                   Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot[0].AvailableSlots[0].StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
               },
               slot =>
               {
                   Assert.Equal("Nexus", slot[0].Email);
                   Assert.Equal(new DateTime(2021, 09, 23, 15, 30, 00), slot[0].AvailableSlots[0].StartTime);
                   Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
               },
               slot =>
               {
                   Assert.Equal("Nexus", slot[0].Email);
                   Assert.Equal(new DateTime(2021, 09, 24, 15, 30, 00), slot[0].AvailableSlots[0].StartTime);
                   Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
               },
                slot =>
                {
                    Assert.Equal("Nexus", slot[0].Email);
                    Assert.Equal(new DateTime(2021, 09, 25, 08, 00, 00), slot[0].AvailableSlots[0].StartTime);
                    Assert.Equal(new DateTime(2021, 09, 25, 17, 00, 00), slot[0].AvailableSlots[0].EndTime);
                });
        }
    }
}

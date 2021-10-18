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
//    public class GetFinalSlotsTests
//    {
//        [Fact]
//        public void Available_Slots_For_Agile_Test()
//        {
//            // Arrange

//            var booking = new BookingService();
//            var calenderService = new CalendarService();
//            var list = new List<AvailableSlot>();
//            var room = new Room();
//            var person = new Person();
//            person.Email = "Terrence";

//            List<Person> listOfNames = new List<Person>()
//            {
//                new()
//                {
//                    Email = "Terrence",
//                },
//               new()
//               {
//                   Email = "Hans"
//               },
//            };

//            person = calenderService.FindPerson(person.Email);
//            var people = calenderService.FindPeople(listOfNames.ToArray());


//            room.Email = "Cloud";

//            room = calenderService.FindRoom(room.Email);


//            double duration = 61;

//            var listOfRooms = new List<Room>();

//            var rooms = calenderService.GetRooms();

//            listOfRooms.Add(room);

//            var availableSlots = booking.CalculateAvailableRooms(Convert.ToDouble(duration), rooms.ToArray());

//            var availableRooms = booking.CalculateAvailableSlots(person, people.ToArray(), Convert.ToDouble(duration));

         

//            // Act

//            var results = booking.GetFinalSlots(availableRooms, availableSlots);

//            // Assert

//            Assert.NotNull(results);
//            Assert.Collection(results,
//               slot =>
//               {
//                   Assert.Equal(new DateTime(2021, 09, 22, 11, 45, 00), slot.StartTime);
//                   Assert.Equal(new DateTime(2021, 09, 22, 13, 00, 00), slot.EndTime);
//               },
//                slot =>
//                {
//                    Assert.Equal(new DateTime(2021, 09, 22, 13, 30, 00), slot.StartTime);
//                    Assert.Equal(new DateTime(2021, 09, 22, 15, 00, 00), slot.EndTime);
//                },
//                slot =>
//                {
//                    Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot.StartTime);
//                    Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot.EndTime);
//                },
//                 slot =>
//                 {
//                     Assert.Equal(new DateTime(2021, 09, 23, 11, 45, 00), slot.StartTime);
//                     Assert.Equal(new DateTime(2021, 09, 23, 13, 00, 00), slot.EndTime);
//                 },
//                slot =>
//                {
//                    Assert.Equal(new DateTime(2021, 09, 23, 13, 30, 00), slot.StartTime);
//                    Assert.Equal(new DateTime(2021, 09, 23, 15, 00, 00), slot.EndTime);
//                });
//        }
//    }
//}

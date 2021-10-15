using LocalBookings.Models;
using LocalBookings.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace BookingTest
{
    public class BookingTest
    {
        private int Add(int a, int b)
        {
            return a + b;
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void TestAdd(int answer, int a, int b)
        {
            // act
            var result = Add(a, b);

            // assert
            Assert.Equal(answer, result);
        }

        public static IEnumerable<object[]> GetData()
        {
            return new object[][]
            {
                new object[] {5, 2, 3},
                new object[] {15, 2, 13}
            };
        }


        [Fact]
        public void Available_Slots_For_One_Person_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var person = new Person();
            person.Email = "Terrence";

            double duration = 61;



            List<Person> listOfNames = new List<Person>()
            {
                new()
                {
                    Email = "Terrence",
                },

            };

            var listOfRooms = new List<Room>();
            person = calenderService.FindPerson(person.Email);
            var people = calenderService.FindPeople(listOfNames.ToArray());

            // Act

            var results = booking.CalculateAvailableSlots(person, people, duration, listOfRooms.ToArray());

            // Assert

            Assert.NotNull(results);
            Assert.Equal(6, results.Length);
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
                     Assert.Equal(new DateTime(2021, 09, 23, 10, 00, 00), slot.StartTime);
                     Assert.Equal(new DateTime(2021, 09, 23, 15, 00, 00), slot.EndTime);
                 },
                 slot =>
                 {
                     Assert.Equal(new DateTime(2021, 09, 23, 15, 30, 00), slot.StartTime);
                     Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot.EndTime);
                 },
                 slot =>
                 {
                     Assert.Equal(new DateTime(2021, 09, 24, 10, 00, 00), slot.StartTime);
                     Assert.Equal(new DateTime(2021, 09, 24, 15, 00, 00), slot.EndTime);
                 },
                 slot =>
                 {
                     Assert.Equal(new DateTime(2021, 09, 24, 15, 30, 00), slot.StartTime);
                     Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot.EndTime);
                 });

        }

        [Fact]
        public void Available_Slots_For_Two_People_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var person = new Person();
            person.Email = "Terrence";

            double duration = 61;



            List<Person> listOfNames = new List<Person>()
            {
                new()
                {
                    Email = "Terrence",
                },
               new()
               {
                   Email = "Hans"
               },
            };

            var listOfRooms = new List<Room>();
            person = calenderService.FindPerson(person.Email);
            var people = calenderService.FindPeople(listOfNames.ToArray());

            // Act

            var results = booking.CalculateAvailableSlots(person, people, duration, listOfRooms.ToArray());

            // Assert

            Assert.NotNull(results);
            Assert.Equal(9, results.Length);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 22, 11, 45, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 13, 00, 00), slot.EndTime);
               },
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 22, 13, 30, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 22, 15, 00, 00), slot.EndTime);
                },
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot.EndTime);
                },
                 slot =>
                 {
                     Assert.Equal(new DateTime(2021, 09, 23, 11, 45, 00), slot.StartTime);
                     Assert.Equal(new DateTime(2021, 09, 23, 13, 00, 00), slot.EndTime);
                 },
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 23, 13, 30, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 23, 15, 00, 00), slot.EndTime);
                },
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 23, 15, 30, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot.EndTime);
                },
                 slot =>
                 {
                     Assert.Equal(new DateTime(2021, 09, 24, 11, 45, 00), slot.StartTime);
                     Assert.Equal(new DateTime(2021, 09, 24, 13, 00, 00), slot.EndTime);
                 },
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 24, 13, 30, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 24, 15, 00, 00), slot.EndTime);
                },
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 24, 15, 30, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot.EndTime);
                });
        }

        [Fact]
        public void Available_Slots_For_Three_People_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var person = new Person();
            person.Email = "Terrence";

            double duration = 61;



            List<Person> listOfNames = new List<Person>()
            {
                new()
                {
                    Email = "Terrence",
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

            var listOfRooms = new List<Room>();
            person = calenderService.FindPerson(person.Email);
            var people = calenderService.FindPeople(listOfNames.ToArray());

            // Act

            var results = booking.CalculateAvailableSlots(person, people, duration, listOfRooms.ToArray());

            // Assert

            Assert.NotNull(results);
            Assert.Equal(3, results.Length);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 23, 15, 30, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 24, 15, 30, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot.EndTime);
               });



        }

        [Fact]
        public void Available_Slots_For_Two_People_Including_Organiser_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var person = new Person();
            person.Email = "Terrence";

            double duration = 61;



            List<Person> listOfNames = new List<Person>()
            {
               new()
               {
                   Email = "Hans"
               },
               new()
               {
                   Email = "Amanda"
               }
            };

            var listOfRooms = new List<Room>();
            person = calenderService.FindPerson(person.Email);
            var people = calenderService.FindPeople(listOfNames.ToArray());

            // Act

            var results = booking.CalculateAvailableSlots(person, people, duration, listOfRooms.ToArray());

            // Assert

            Assert.NotNull(results);
            Assert.Equal(3, results.Length);
            Assert.Collection(results,
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 22, 15, 30, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 22, 17, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 23, 15, 30, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot.EndTime);
               },
               slot =>
               {
                   Assert.Equal(new DateTime(2021, 09, 24, 15, 30, 00), slot.StartTime);
                   Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot.EndTime);
               });


        }

        [Fact]
        public void Available_Slots_For_Organiser_Only_Test()
        {
            // Arrange

            var booking = new BookingService();
            var calenderService = new CalendarService();
            var person = new Person();
            person.Email = "Terrence";

            double duration = 61;



            List<Person> listOfNames = new List<Person>()
            {
                new()
                {
                    Email = "Neil",
                },

            };

            var listOfRooms = new List<Room>();
            person = calenderService.FindPerson(person.Email);
            var people = calenderService.FindPeople(listOfNames.ToArray());

            // Act

            var results = booking.CalculateAvailableSlots(person, people, duration, listOfRooms.ToArray());

            // Assert

            Assert.NotNull(results);
            Assert.Equal(6, results.Length);
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
                    Assert.Equal(new DateTime(2021, 09, 23, 10, 00, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 23, 15, 00, 00), slot.EndTime);
                },
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 23, 15, 30, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 23, 17, 00, 00), slot.EndTime);
                },
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 24, 10, 00, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 24, 15, 00, 00), slot.EndTime);
                },
                slot =>
                {
                    Assert.Equal(new DateTime(2021, 09, 24, 15, 30, 00), slot.StartTime);
                    Assert.Equal(new DateTime(2021, 09, 24, 17, 00, 00), slot.EndTime);
                });


        }
    }
}

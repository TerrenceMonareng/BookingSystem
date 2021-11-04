using Infrastructure.Services.Interfarces.BookingService;
using Infrastructure.Services.Interfarces.CalendarServices;
using LocalBookings.Models;
using LocalBookings.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalBookings
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Services

            IPeopleService peopleService = Factory.CreatePersonService();
            IRoomsService roomService = Factory.CreateRoomService();
            IRoomsCalendar roomsCalendar = Factory.CreateRoomsCalendar();
            IPeopleCalendar peopleCalendar = Factory.CreatePeopleCalendar();
            IPeopleAndRoomsService peopleAndRoomsService = Factory.CreatePeopleAndRoomService();

            #endregion

            var name = new Person();
           
            var room = new Room();

            var rooms = new List<Room>();

            rooms = roomsCalendar.GetRooms();

            var listOfPeople = new List<Person>();

            listOfPeople = peopleCalendar.GetPeople();



            #region Enter User name 

            Console.WriteLine("user name");
            Console.WriteLine();
            name.Email = Console.ReadLine();
            name = peopleCalendar.FindPerson(name.Email);

            while (true)
            {
                if (name.Email != null)
                {
                    Console.WriteLine("your name is:" + name.Email);
                    break;
                }
                else
                {
                    Console.WriteLine("please select a valid name");
                    Console.WriteLine();
                    name.Email = Console.ReadLine();
                    name = peopleCalendar.FindPerson(name.Email);
                }

            }

            Console.WriteLine();

            #endregion


            #region select people and print required to attend  

            foreach (var item in listOfPeople)
            {
                Console.WriteLine(item.Email);
            }
            Console.WriteLine();
            Console.WriteLine("please select required people or person to attend from the list above");

            var listOfNames = new List<Person>();

            string[] requirePeople = Console.ReadLine().Split();
            Console.WriteLine();

            foreach (var person in requirePeople)
            {
                var pers = new Person();

                pers.Email = person;

                listOfNames.Add(pers);
            }
            var people = peopleCalendar.FindPeople(listOfNames.ToArray());


            Console.WriteLine();

            while (true)

            {
                if (people.Length != 0)
                {
                    Console.WriteLine("required people are");
                    Console.WriteLine();
                    foreach (var item in people)
                    {
                        Console.WriteLine(item.Email); //printing required people

                    }
                    break;
                }
                else
                {
                    if (people.Length != 0)
                    {
                        break;
                    }
                    Console.WriteLine("please select valid person");
                    Console.WriteLine();
                    requirePeople = Console.ReadLine().Split();

                    foreach (var person in requirePeople)
                    {
                        var pers = new Person();

                        pers.Email = person;

                        listOfNames.Add(pers);
                    }

                }

            }
            Console.WriteLine();

            #endregion

            #region select and display duration and available slots 

            Console.WriteLine("please select duration for the meeting");
            Console.WriteLine();
            var duration = Console.ReadLine();

 

            Console.WriteLine("your selected duration is: " + duration + " minutes");
            Console.WriteLine();

            #endregion


            #region Displaying available Rooms 

            var availableSlots = peopleService.CalculateAvailableSlots(name, people, Convert.ToDouble(duration));

            var listOfAvailableRooms = peopleAndRoomsService.GetAVailableSlotsForAllRooms(rooms, availableSlots, Convert.ToDouble(duration));

            var combinedAvailableSlots = peopleAndRoomsService.CombineFinalAvailableSlots(listOfAvailableRooms);

            Console.WriteLine("The Available Rooms and time slots for your required people are shown below");


            Console.WriteLine();


            for (int i = 0; i < combinedAvailableSlots[0].Email.Count(); i++)
            {
                Console.WriteLine("From " + combinedAvailableSlots[0].StartTime[i] + " To " + combinedAvailableSlots[0].EndTime[i] + " Room Name " + combinedAvailableSlots[0].Email[i]);
            }
            Console.WriteLine();

            #endregion

            #region select a Room 

            Console.WriteLine("Please select available room from the list above ");


            room.Email = Console.ReadLine();
            room = roomsCalendar.FindRoom(room.Email);


            var room1 = new List<Room>();

            room1.Add(room);


            var retrieveAvailableRooms = roomService.CalculateAvailableRooms(Convert.ToDouble(duration), room1.ToArray());


            var Availiable = peopleAndRoomsService.GetAvailableSlotsForPeopleAndRoom(retrieveAvailableRooms, availableSlots);


            while (true)
            {
                if (room.Email != null && retrieveAvailableRooms.Length > 0)
                {
                    Console.WriteLine("Your selected room is: " + room.Email);
                    break;
                }
                else
                {
                    Console.WriteLine("Please select a valid room from the available rooms below");

                    foreach (var item in retrieveAvailableRooms)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    room.Email = Console.ReadLine();
                    room = roomsCalendar.FindRoom(room.Email);
                    retrieveAvailableRooms = roomService.CalculateAvailableRooms(Convert.ToDouble(duration), room1.ToArray());

                }

            }

            Console.WriteLine();

            #endregion

            #region Displaying Available slots 

            Console.WriteLine("Available time slots for "  +room.Email+ " And required people are shown below:");
            Console.WriteLine();

            if (Availiable.Length != 0)
            {
                foreach (var item in Availiable)
                {
                    Console.WriteLine("From: " + item.StartTime + " To " + item.EndTime);
                }
            }
            else
            {
                Console.WriteLine("user has no events");
            }

            Console.WriteLine();

            #endregion


            #region Displaying your selected time Slots

            TimeSpan interval = TimeSpan.FromMinutes(Convert.ToDouble(duration));

            for (int i = 0; i < Availiable.Length; i++)
            {
                Console.WriteLine("please select available slots Number from list above");
                Console.WriteLine();
                i = Convert.ToInt32(Console.ReadLine());


                while (true)
                {
                    if (i < Availiable.Length)
                    {

                        Console.WriteLine("your selected slot is: " + Availiable[i].StartTime + " To " + Availiable[i].StartTime.Add(interval));
                        Console.WriteLine();




                        Console.WriteLine("Enter subject for meeting");
                        Console.WriteLine();
                        var subject = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Subject for your meeting is: " + subject);
                        Console.WriteLine();

                        Console.WriteLine("Request sent.....");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("please select available slot");
                        Console.WriteLine();
                        i = Convert.ToInt32(Console.ReadLine());

                    }

                }
                break;
            }
            #endregion

            Console.ReadLine();
        }
    }
}

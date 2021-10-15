using LocalBookings.Models;
using LocalBookings.Services;
using System;
using System.Collections.Generic;

namespace LocalBookings
{
    class Program
    {
        static void Main(string[] args)
        {

           
            Console.WriteLine(DateTime.DaysInMonth(2021, 10).ToString());
            var name = new Person();
            var calenderService = new CalendarService();

            var room = new Room();

            var rooms = new List<Room>();

            rooms = calenderService.GetRooms();

            var listOfPeople = new List<Person>();

            listOfPeople = calenderService.GetPeople();



            // Enter User name ********************************************************************************************************************************************

            Console.WriteLine("user name");
            Console.WriteLine();
            name.Email = Console.ReadLine();
            name = calenderService.FindPerson(name.Email);

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
                    name = calenderService.FindPerson(name.Email);
                }

            }

            Console.WriteLine();

            foreach (var item in rooms)
            {
                Console.WriteLine(item.Email);
            }
            Console.WriteLine();
            Console.WriteLine("Please select available room from the list above ");

            room.Email = Console.ReadLine();
            room = calenderService.FindRoom(room.Email);


            // select room   ***********************************************************************************************************************************************


            while (true)
            {
                if (room.Email != null)
                {
                    Console.WriteLine("Your selected room is: " + room.Email);
                    break;
                }
                else
                {
                    Console.WriteLine("Please select a valid room");
                    Console.WriteLine();
                    room.Email = Console.ReadLine();
                    room = calenderService.FindRoom(room.Email);

                }

            }
            Console.WriteLine();


            // select people and print required to attend  *****************************************************************************************************************************

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
            var people = calenderService.FindPeople(listOfNames.ToArray());


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


            // select and display duration and available slots  ****************************************************************************************************************

            Console.WriteLine("please select duration for the meeting");
            Console.WriteLine();
            var duration = Console.ReadLine();

            var bookingService = new BookingService();

            Console.WriteLine("your selected duration is: " + duration + " minutes");

            var availableSlots = bookingService.CalculateAvailableSlots(name, people, Convert.ToDouble(duration), rooms.ToArray());


            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Available time slots for required people are shown below:");
            Console.WriteLine();

            if (availableSlots.Length != 0)
            {
                DisplayeSlots(availableSlots);
            }
            else
            {
                Console.WriteLine("user has no events");
            }


            void DisplayeSlots(AvailableSlot[] availableSlots)
            {
                foreach (var item in availableSlots)
                {
                    Console.WriteLine("From: " + item.StartTime + " To " + item.EndTime);

                }

            }
            Console.WriteLine();

            TimeSpan interval = TimeSpan.FromMinutes(Convert.ToDouble(duration));

            for (int i = 0; i < availableSlots.Length; i++)
            {
                Console.WriteLine("please select available slots Number from list above");
                Console.WriteLine();
                i = Convert.ToInt32(Console.ReadLine());


                while (true)
                {
                    if (i < availableSlots.Length)
                    {

                        Console.WriteLine("your selected slot is: " + availableSlots[i].StartTime + " To " + availableSlots[i].StartTime.Add(interval));
                        Console.WriteLine();




                        Console.WriteLine("Enter subject for meeting");
                        var subject = Console.ReadLine();
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


            Console.ReadLine();
        }
    }
}

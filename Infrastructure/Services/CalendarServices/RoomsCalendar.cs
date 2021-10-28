using Infrastructure.Services.Interfarces;
using Infrastructure.Services.Interfarces.CalendarServices;
using LocalBookings.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services.CalendarServices
{
    public class RoomsCalendar : IRoomsCalendar
    {
        private readonly List<Room> listOfRoomEvents = new List<Room>()
            {
                new()
                {
                    Email = "Agile", Events = new Event[]
                    {
                        new()
                        {
                            StartTime= new DateTime(2021,09,22,07,00,00),
                            EndTime = new DateTime(2021,09,22,08,00,00)


                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,22,09,00,00),
                            EndTime = new DateTime(2021,09,22,10,00,00)

                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,22,15,00,00),
                            EndTime = new DateTime(2021,09,22,15,30,00)

                        },
                         new()
                        {
                            StartTime= new DateTime(2021,09,23,07,00,00),
                            EndTime = new DateTime(2021,09,23,08,00,00)
                        }
                    }
                },
                new()
                {
                    Email = "Cloud", Events = new Event[]
                    {
                         new()
                        {
                            StartTime= new DateTime(2021,09,22,08,00,00),
                            EndTime = new DateTime(2021,09,22,09,00,00)


                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,22,11,00,00),
                            EndTime = new DateTime(2021,09,22,11,45,00)

                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,22,13,00,00),
                            EndTime = new DateTime(2021,09,22,13,30,00)

                        }
                    }
                },
                new()
                {
                    Email = "Nexus", Events = new Event[]
                    {
                        new()
                        {
                            StartTime= new DateTime(2021,09,22,10,00,00),
                            EndTime = new DateTime(2021,09,22,11,00,00)


                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,22,12,00,00),
                            EndTime = new DateTime(2021,09,22,13,00,00)

                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,22,14,00,00),
                            EndTime = new DateTime(2021,09,22,14,30,00)

                        }
                    }
                }
            };

        public Room FindRoom(string roomName)
        {
            var room = new Room();

            foreach (var item in listOfRoomEvents)
            {
                if (roomName == item.Email)
                {
                    room.Email = roomName;
                    room.Events = item.Events;
                }
            }
            return room;
        }

        public List<Room> GetRooms()
        {
            var rooms = new List<Room>();

            foreach (var item in listOfRoomEvents)
            {
                rooms.Add(item);
            }

            return rooms;

        }
    }
}

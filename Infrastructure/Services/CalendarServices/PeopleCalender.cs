using Infrastructure.Services.Interfarces;
using Infrastructure.Services.Interfarces.CalendarServices;
using LocalBookings.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services.CalendarServices
{
    public class PeopleCalender : IPeopleCalender
    {
        private readonly List<Person> listEvents = new List<Person>()
            {
                new()
                {
                    Email = "Terrence", Events = new Event[]
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


                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,23,09,00,00),
                            EndTime = new DateTime(2021,09,23,10,00,00)

                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,23,15,00,00),
                            EndTime = new DateTime(2021,09,23,15,30,00)

                        },
                         new()
                        {
                            StartTime= new DateTime(2021,09,24,07,00,00),
                            EndTime = new DateTime(2021,09,24,08,00,00)


                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,24,09,00,00),
                            EndTime = new DateTime(2021,09,24,10,00,00)

                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,24,15,00,00),
                            EndTime = new DateTime(2021,09,24,15,30,00)

                        }
                    }
                },
                new()
                {
                    Email = "Hans", Events = new Event[]
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

                        },
                          new()
                        {
                            StartTime= new DateTime(2021,09,23,08,00,00),
                            EndTime = new DateTime(2021,09,23,09,00,00)


                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,23,11,00,00),
                            EndTime = new DateTime(2021,09,23,11,45,00)

                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,23,13,00,00),
                            EndTime = new DateTime(2021,09,23,13,30,00)

                        },
                          new()
                        {
                            StartTime= new DateTime(2021,09,24,08,00,00),
                            EndTime = new DateTime(2021,09,24,09,00,00)


                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,24,11,00,00),
                            EndTime = new DateTime(2021,09,24,11,45,00)

                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,24,13,00,00),
                            EndTime = new DateTime(2021,09,24,13,30,00)

                        }
                    }
                },
                new()
                {
                    Email = "Amanda", Events = new Event[]
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

                        },
                         new()
                        {
                            StartTime= new DateTime(2021,09,23,10,00,00),
                            EndTime = new DateTime(2021,09,23,11,00,00)


                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,23,12,00,00),
                            EndTime = new DateTime(2021,09,23,13,00,00)

                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,23,14,00,00),
                            EndTime = new DateTime(2021,09,23,14,30,00)

                        },
                         new()
                        {
                            StartTime= new DateTime(2021,09,24,10,00,00),
                            EndTime = new DateTime(2021,09,24,11,00,00)


                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,24,12,00,00),
                            EndTime = new DateTime(2021,09,24,13,00,00)

                        },
                        new()
                        {
                            StartTime= new DateTime(2021,09,24,14,00,00),
                            EndTime = new DateTime(2021,09,24,14,30,00)

                        }
                    }
                }
            };

        public Person FindPerson(string emailAddress)
        {
            var person = new Person();

            foreach (var item in listEvents)
            {
                if (emailAddress == item.Email)
                {
                    person.Email = emailAddress;
                    person.Events = item.Events;
                }
            }
            return person;
        }

        public Person[] FindPeople(Person[] email)
        {
            List<Person> people = new List<Person>();

            foreach (var item in listEvents)
            {
                foreach (var item1 in email)
                {
                    if (item1.Email == item.Email)
                    {
                        people.Add(item);
                    }

                }
            }
            return people.ToArray();
        }

        public List<Person> GetPeople()
        {
            var listOfPeople = new List<Person>();

            foreach (var item in listEvents)
            {
                listOfPeople.Add(item);
            }

            return listOfPeople;
        }
    }
}

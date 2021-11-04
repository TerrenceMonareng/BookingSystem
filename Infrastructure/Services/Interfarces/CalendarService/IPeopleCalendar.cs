using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.CalendarServices
{
   public interface IPeopleCalendar
    {
        /// <summary>
        /// This function find a person from the calendar
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Person FindPerson(string emailAddress);

        /// <summary>
        /// This funcion Find a list of people from a calendar
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Person[] FindPeople(Person[] email);

        /// <summary>
        /// This function retrieves the the list of all the the people on the calendar
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPeople();
    }
}

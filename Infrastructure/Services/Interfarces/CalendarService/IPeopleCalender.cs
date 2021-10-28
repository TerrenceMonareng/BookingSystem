using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.CalendarServices
{
   public interface IPeopleCalender
    {
        Person FindPerson(string emailAddress);
        public Person[] FindPeople(Person[] email);

        public List<Person> GetPeople();
    }
}

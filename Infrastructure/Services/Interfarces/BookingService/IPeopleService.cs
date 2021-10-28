using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.BookingService
{
    public interface IPeopleService
    {
        IEnumerable<AvailableSlot> GetAvailableSlots(DateTime dayStart, DateTime dayEnd, Person[] required);
        AvailableSlot[] CalculateAvailableSlots(Person organiser, Person[] required, double duration);

    }
}

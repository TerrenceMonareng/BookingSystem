using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.BookingService
{
    public interface IPeopleAndRoomServices
    {
        AvailableSlot[] GetFinalSlots(IEnumerable<AvailableSlot> listRoom1, AvailableSlot[] listPeople1);

        List<FinalAvailableSlots[]> GetAVailableSlotsForAllRooms(IEnumerable<Room> rooms, AvailableSlot[] availableSlots, double duration);
        List<AvailableSlots> CombineFinalAvailableSlots(List<FinalAvailableSlots[]> combinedAvailableSlots);
    }
}

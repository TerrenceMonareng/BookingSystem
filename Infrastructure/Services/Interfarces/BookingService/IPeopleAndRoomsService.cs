using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfarces.BookingService
{
    public interface IPeopleAndRoomsService
    {
        /// <summary>
        /// This function takes the available rooms and available slots for people and retrieves the open slots
        /// </summary>
        /// <param name="listRoom1"></param>
        /// <param name="listPeople1"></param>
        /// <returns></returns>
        AvailableSlot[] GetAvailableSlotsForPeopleAndRoom(IEnumerable<AvailableSlot> listRoom1, AvailableSlot[] listPeople1);

        /// <summary>
        /// This function retrieves the all the available rooms and their available slots
        /// </summary>
        /// <param name="rooms"></param>
        /// <param name="availableSlots"></param>
        /// <param name="duration"></param>
        /// <returns></returns>

        List<FinalAvailableSlots[]> GetAVailableSlotsForAllRooms(IEnumerable<Room> rooms, AvailableSlot[] availableSlots, double duration);

        /// <summary>
        /// This function sort the available slots for rooms with simila available slots together
        /// </summary>
        /// <param name="combinedAvailableSlots"></param>
        /// <returns></returns>
        List<AvailableSlots> CombineFinalAvailableSlots(List<FinalAvailableSlots[]> combinedAvailableSlots);

      
    }
}

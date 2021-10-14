using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalBookings.Services
{
    public class BookingService
    {
        internal IEnumerable<AvailableSlot> GetAvailableSlots(DateTime dayStart, DateTime dayEnd, Person[] required)
        {
            List<Event> filtered = new List<Event>();
            List<AvailableSlot> availableSlots = new List<AvailableSlot>();

            var newDayStart = DateTime.MinValue;
            var newDayEnd = DateTime.MinValue;

            // Flatterning the arrays

            var flattenedArray = required.SelectMany(m => m.Events).ToArray();

            // Sorting up source list
            filtered = flattenedArray.OrderBy(o => o.StartTime).ToList();

            foreach (var item in filtered)
            {
                var day = dayStart.AddDays(item.StartTime.Day).Day;
                var month = dayStart.AddMonths(item.StartTime.Month).Month;
                var years = dayStart.AddYears(item.StartTime.Year).Year;
                var day1 = dayEnd.AddDays(item.StartTime.Day).Day;
                var month1 = dayEnd.AddMonths(item.StartTime.Month).Month;
                var year1 = dayEnd.AddYears(item.StartTime.Year).Year;
         
                newDayStart = new DateTime((years - 1), (month - 1), (day - 1), 08, 00, 00);
                newDayEnd = new DateTime((year1 - 1), (month1 - 1), (day1 - 1), 17, 00, 00);
            }

            var previousEnd = newDayStart;

            foreach (var range in filtered)
            {
                // checking the length of time between previous end and current start

                var openTime = range.StartTime.Subtract(previousEnd);

                if (openTime.TotalMinutes > 0)
                {
                    var slot = new AvailableSlot
                    {
                        StartTime = previousEnd,
                        EndTime = range.StartTime
                    };

                    if (slot.EndTime.Subtract(slot.StartTime).TotalMinutes <= 540)
                    {
                        availableSlots.Add(slot);
                    }
                    else
                    {
                        var setEndTime = DateTime.MinValue;

                        var setDay = setEndTime.AddDays(slot.StartTime.Day).Day;
                        var setMonth = setEndTime.AddMonths(slot.StartTime.Month).Month;
                        var setYear = setEndTime.AddYears(slot.StartTime.Year).Year;

                        slot.EndTime = new DateTime((setYear - 1), (setMonth - 1), (setDay - 1), 17, 00, 00);
                        availableSlots.Add(slot);
                    }

                    availableSlots.Add(slot);
                }

                // update tracking for new previous end

                previousEnd = range.EndTime;

            }
            // Finally, check for open slot at the end of the day

            if (newDayEnd.Subtract(previousEnd).TotalMinutes > 0)
            {
                var slot1 = new AvailableSlot
                {
                    StartTime = previousEnd,
                    EndTime = newDayEnd
                };
                availableSlots.Add(slot1);
            }

            // Removing duplicates

            var combinedAvailableSlotsListWithoutDuplicates = availableSlots.GroupBy(x => x.StartTime).Select(g => g.OrderByDescending(x => x.EndTime).FirstOrDefault());

            return combinedAvailableSlotsListWithoutDuplicates;

        }


        public AvailableSlot[] CalculateAvailableSlots(Person organiser, Person[] required, double duration, Room[] allRooms)
        {
            DateTime DayStart = DateTime.MinValue;
            DateTime DayEnd = DateTime.MinValue;

            var availableSlots = GetAvailableSlots(DayStart, DayEnd, required.Union(new[] { organiser }).ToArray());

            List<AvailableSlot> filteredAvailableSlots = new List<AvailableSlot>();

            foreach (var item in availableSlots)
            {
                var slots = item.EndTime.Subtract(item.StartTime);

                var minutes = slots.TotalMinutes;
                if (minutes >= duration)
                {
                    filteredAvailableSlots.Add(item);
                }
            }

            return filteredAvailableSlots.ToArray();

        }
    }


}
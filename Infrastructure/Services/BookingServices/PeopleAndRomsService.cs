using Infrastructure.Services.Interfarces.BookingService;
using LocalBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.BookingServices
{
   public class PeopleAndRomsService : IPeopleAndRoomServices
    {
        private IRoomService _roomService;

        public PeopleAndRomsService(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public AvailableSlot[] GetFinalSlots(IEnumerable<AvailableSlot> listRoom1, AvailableSlot[] listPeople1)
        {

            var listRoom = listRoom1.OrderBy(x => x.StartTime);
            var listPeople = listPeople1.OrderBy(x => x.StartTime);

            var List = new List<AvailableSlot>();
            AvailableSlot slot = new AvailableSlot();

            foreach (var item in listRoom)
            {
                foreach (var item2 in listPeople)
                {
                    // checking for overlap

                    if (item.StartTime < item2.EndTime && item2.StartTime < item.EndTime)
                    {
                        if (item.EndTime >= item2.EndTime && item.StartTime >= item2.StartTime)
                        {

                            var slot1 = new AvailableSlot
                            {
                                StartTime = item.StartTime,
                                EndTime = item2.EndTime

                            };
                            List.Add(slot1);
                        }
                        else if (item.EndTime <= item2.EndTime && item.StartTime <= item2.StartTime)
                        {

                            var slot1 = new AvailableSlot
                            {
                                StartTime = item2.StartTime,
                                EndTime = item.EndTime
                            };
                            List.Add(slot1);
                        }
                        else if (item.EndTime >= item2.EndTime && item.StartTime <= item2.StartTime)
                        {

                            var slot1 = new AvailableSlot
                            {
                                StartTime = item2.StartTime,
                                EndTime = item2.EndTime
                            };
                            List.Add(slot1);
                        }

                    }

                }

            }

            return List.ToArray();
        }
        public List<FinalAvailableSlots[]> GetAVailableSlotsForAllRooms(IEnumerable<Room> rooms, AvailableSlot[] availableSlots, double duration)
        {
            var availableRoomsList = new List<Room>();
            var availableRoomsList1 = new List<FinalAvailableSlots[]>();

            foreach (var item in rooms)
            {
                availableRoomsList.Add(item);
                var availableRoomSLots = _roomService.CalculateAvailableRooms(duration, availableRoomsList.ToArray());


                var availableRooms = GetFinalSlots(availableRoomSLots, availableSlots);

                if (availableRooms.Count() > 0)
                {
                    foreach (var item1 in availableRooms)
                    {
                        var slot = new FinalAvailableSlots[]

                        {
                            new()
                            {
                                Email =item.Email,
                                AvailableSlots = new AvailableSlot[]
                                {
                                    new()
                                    {
                                        StartTime =item1.StartTime,
                                        EndTime = item1.EndTime
                                    }
                                }
                            }
                        };

                        availableRoomsList1.Add(slot);
                    }

                    availableRoomsList.Remove(item);
                }

                if (availableRooms.Count() == 0)
                {
                    availableRoomsList.Remove(item);
                }

            }

            return availableRoomsList1;
        }

        public List<AvailableSlots> CombineFinalAvailableSlots(List<FinalAvailableSlots[]> combinedAvailableSlots)
        {
            var events = new List<AvailableSlots>();

            var mystart = new List<DateTime>();
            var myend = new List<DateTime>();
            var myemails = new List<String>();


            foreach (var item in combinedAvailableSlots)
            {
                var itemx = item[0];

                bool hit = false;

                for (int i = 0; i < mystart.Count(); i++)
                {
                    if (mystart[i] == itemx.AvailableSlots[0].StartTime && myend[i] == itemx.AvailableSlots[0].EndTime)
                    {
                        hit = true;
                        myemails[i] = myemails[i] + ", " + itemx.Email;
                        break;
                    }
                }
                if (hit == false)
                {
                    mystart.Add(itemx.AvailableSlots[0].StartTime);
                    myend.Add(itemx.AvailableSlots[0].EndTime);
                    myemails.Add(itemx.Email);
                }

            }

            var slot = new AvailableSlots
            {
                Email = myemails,
                StartTime = mystart,
                EndTime = myend
            };

            events.Add(slot);



            return events;
        }
    }
}

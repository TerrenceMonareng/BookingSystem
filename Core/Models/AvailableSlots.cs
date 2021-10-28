using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBookings.Models
{
   public class AvailableSlots
    {
        public List<string> Email { get; set; }

        public List<DateTime> StartTime  { get; set; }
        public List<DateTime> EndTime { get; set; }
    }
}

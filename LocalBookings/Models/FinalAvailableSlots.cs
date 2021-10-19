using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBookings.Models
{
    public class FinalAvailableSlots
    {
        public string Email { get; set; }
        public AvailableSlot[] AvailableSlots { get; set; }
    }
}

using EFCoreHotel_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.Interface
{
    public interface IGuestService
    {
        public IEnumerable<Guest> GetGuests();
        public void AddGuest(Guest guest);
        public int GetMaxGuestNo();
        public Guest GetGuest(int guestNo);

        public void RemoveGuest(int guestNo);
    }
}

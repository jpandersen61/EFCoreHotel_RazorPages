using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreHotel_RazorPages.Services.EFService
{
    public class EFGuestService:IGuestService
    {
        private HoteldbContext context;
        public EFGuestService(HoteldbContext service)
        {
            context = service;
        }
        public IEnumerable<Guest> GetGuests()
        {
            return context.Guests;
        }

        public void AddGuest(Guest guest)
        {
            context.Guests.Add(guest);
            context.SaveChanges();
        }

        public int GetMaxGuestNo()
        {
            int result = 0;

            if (context.Guests.Count<Guest>() > 0)
            {
                result = context.Guests.ToList<Guest>().Max<Guest>(g => g.GuestNo);
            }

            return result;
        }

        public Guest GetGuest(int guestNo)
        {
            Guest result = null;

            result = context.Guests.Find(guestNo);

            return result;
        }

        public void RemoveGuest(int guestNo)
        {
            context.Guests.Remove(GetGuest(guestNo));
            context.SaveChanges();
        }
    }
}

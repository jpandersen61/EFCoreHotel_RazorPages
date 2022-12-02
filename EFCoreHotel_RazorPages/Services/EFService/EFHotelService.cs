using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;




namespace EFCoreHotel_RazorPages.Services.EFService
{
    public class EFHotelService:IHotelService
    {
        private  HoteldbContext  context;
        public EFHotelService(HoteldbContext service)
        {
            context = service;
        }
        public IEnumerable<Hotel> GetHotels()
        {
            return context.Hotels;
        }

        public Hotel GetHotel(int hotelNo)
        {
            var hotel = context.Hotels
            .Include(h => h.Rooms)
            .ThenInclude(r => r.Bookings)
            .ThenInclude(g => g.GuestNoNavigation)
            .AsNoTracking()
            .FirstOrDefault(h => h.HotelNo  == hotelNo);

            return hotel;
        }
    }
}

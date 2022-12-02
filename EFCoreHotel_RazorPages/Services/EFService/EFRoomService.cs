using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.EFService
{
    public class EFRoomService : IRoomService
    {
        private HoteldbContext context;
        public EFRoomService(HoteldbContext service)
        {
            context = service;
        }
        public IEnumerable<Room> GetRooms()
        {
            return context.Rooms;
        }

        public IEnumerable<Room> GetRooms(string typeFilter)
        {
            if (typeFilter == null)
            {
                return context.Rooms;
            }

            return context.Rooms.Where(r => r.Types.StartsWith(typeFilter));
        }

        public IEnumerable<Room> GetRooms(string typeFilter, double priceFrom, double priceTo)
        {
            //IEnumerable<Room> result = context.Rooms;

            IEnumerable<Room> result = context.Rooms
            .Include(r => r.HotelNoNavigation)
            .AsNoTracking();
          
            

            if (typeFilter != null)
            {
                result = result.Where(r => r.Types.StartsWith(typeFilter));
            }

            if (priceFrom > 0)
            {
                result = result.Where(r => r.Price >= priceFrom);
            }

            if (priceTo> 0)
            {
                result = result.Where(r => r.Price <= priceTo);
            }

            return result;

        }

    }
}

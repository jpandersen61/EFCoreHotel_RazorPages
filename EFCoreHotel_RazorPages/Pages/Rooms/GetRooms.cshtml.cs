using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreHotel_RazorPages
{
    public class GetRoomsModel : PageModel
    {
          public IEnumerable<Room> Rooms { get; set; }
       
         IRoomService  roomService;

        [BindProperty(SupportsGet = true)]
        public string RoomType { get; set; }
        [BindProperty(SupportsGet = true)]
        public double PriceFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public double  PriceTo { get; set; } 

        public GetRoomsModel(IRoomService service)
        {
           roomService= service;
        }
        public void OnGet()
        {
             Rooms = roomService.GetRooms(RoomType, PriceFrom, PriceTo);
        }
    }
}
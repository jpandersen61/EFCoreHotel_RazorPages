using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCoreHotel_RazorPages.Services.Interface;
using EFCoreHotel_RazorPages.Models;

namespace EFCoreHotel_RazorPages.Pages.Hotels
{
    public class ShowHotelcshtmlModel : PageModel
    {
        IHotelService hotelService;

        public Hotel Hotel {get; set;}
        public ShowHotelcshtmlModel(IHotelService hService)
        {
            hotelService = hService;
        }
        public void OnGet(int hid)
        {
            Hotel = hotelService.GetHotel(hid);
        }
    }
}

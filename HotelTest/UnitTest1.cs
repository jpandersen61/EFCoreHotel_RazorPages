using EFCoreHotel_RazorPages.Services.EFService;
using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;

namespace HotelTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            HoteldbContext cnt = new HoteldbContext();
            EFGuestService gServ =  new EFGuestService(cnt);

            //Act
            IEnumerable<Guest> guests = gServ.GetGuests();

            //Assert
            foreach(var g in guests)
            {

            }

        }
    }
}
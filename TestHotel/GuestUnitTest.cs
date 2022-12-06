using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Services.EFService;
using System.Collections.Generic;
using System.Linq;
using EFCoreHotel_RazorPages.Models;



namespace TestHotel
{
    [TestClass]
    public class GuestUnitTest
    {
        [TestMethod]
        public void TestGuestCollection()
        {
            //Arrange 
            HoteldbContext context = new HoteldbContext();
            EFGuestService guestService = new EFGuestService(context);
            
            //Act
            IEnumerable<Guest> guests = guestService.GetGuests();
            
            //Assert - any exception will the fail
            foreach (Guest g in guests)
            {

            }

            //Clean up
            //Not needed
        }

        [TestMethod]
        public void TestAddGuest()
        {
            //Arrange
            HoteldbContext context = new HoteldbContext();
            EFGuestService guestService = new EFGuestService(context);
            int nextGuestNo = guestService.GetMaxGuestNo() + 1;
            Guest newGuest = new Guest() { Name = "AName", Address = "AnAddress", GuestNo = nextGuestNo };

            //Act
            guestService.AddGuest(newGuest);

            //Assert
            Guest testGuest = guestService.GetGuest(nextGuestNo);
            Assert.AreEqual(newGuest, testGuest);

            //Clean up
            guestService.RemoveGuest(nextGuestNo);
        }

        [TestMethod]
        public void TestGetGuest()
        {
            //Arrange
            HoteldbContext context = new HoteldbContext();
            EFGuestService guestService = new EFGuestService(context);
            IEnumerable<Guest> guests = guestService.GetGuests();

            foreach (Guest gExpected in guests)
            {
                //Act
                Guest guest = guestService.GetGuest(gExpected.GuestNo);

                //Assert
                Assert.AreEqual(gExpected, guest);
            }

            //Clean up
            //Not needed
        }

        [TestMethod]
        public void TestRemoveGuest()
        {
            //Arrange
            HoteldbContext context = new HoteldbContext();
            EFGuestService guestService = new EFGuestService(context);

            //Act
            int nextGuestNo = guestService.GetMaxGuestNo() + 1;
            Guest newGuest = new Guest() { Name = "AName", Address = "AnAddress", GuestNo = nextGuestNo };
            guestService.AddGuest(newGuest);

            Guest testGuest = guestService.GetGuest(nextGuestNo);

            guestService.RemoveGuest(testGuest.GuestNo);        
            
            Guest removeGuest = guestService.GetGuest(nextGuestNo);

            //Assert
            Assert.AreEqual(newGuest, testGuest);
            Assert.IsNull(removeGuest,"Guest seems NOT to have been removed from database");

            //Clean up
            //Not needed
        }
    }
}

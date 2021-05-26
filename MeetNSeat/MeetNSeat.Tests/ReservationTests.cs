using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeetNSeat.Logic;
namespace MeetNSeat.Tests
{
    [TestClass]
    public class ReservationsTests
    {
        [TestMethod]
        public void GetAllReservationsbyuser()
        {
            var u = new User();

            Assert.IsNotNull(u.GetReservationByUser("test"));
        }
        [TestMethod]
        public void GetAllReservations()
        {
            var u = new User();

            Assert.IsNotNull(u.GetAllReservations());
        }
        [TestMethod]
        public void CreateReservation()
        {
            var u = new User();
            u.AddReservation("Conference", 1, "108105466526811947195", 12, 
                Convert.ToDateTime("2021-01-01T12:29"),
                Convert.ToDateTime("2021-01-01T17:00"));
        }

        [TestMethod]
        public void ReservationStartDateTimeInPastShouldBeFalse()
        {
            var u = new User();
            var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12, 
                Convert.ToDateTime("2000-01-01T00:00"),
                Convert.ToDateTime("3000-01-01T00:00"));
            
            Assert.IsFalse(actual);
        }
        
        [TestMethod]
        public void ReservationEndDateTimeInPastShouldBeFalse()
        {
            var u = new User();
            
            var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12, 
                Convert.ToDateTime("3000-01-01T00:00"),
                Convert.ToDateTime("2000-01-01T00:00"));
            
            Assert.IsFalse(actual);
        }
        
        // [TestMethod] TODO: maybe later?
        // public void ReservationShouldNotHaveEnoughSpots()
        // {
        //     var u = new User();
        //     
        //     var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12, 
        //         Convert.ToDateTime("3000-01-01T00:00"),
        //         Convert.ToDateTime("3000-01-01T00:00"));
        //     
        //     Assert.IsFalse(actual);
        // }
        
        [TestMethod]
        public void ReservationStartDateTimeShouldBeFalse()
        {
            var u = new User();
            
            var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12, 
                Convert.ToDateTime("3000-01-01T00:00"),
                Convert.ToDateTime("2000-01-01T00:00"));
            
            Assert.IsFalse(actual);
        }
        
        
        // var span = new TimeSpan(0,0,0, 0, 0);
        //
        // var q = DateTime.Now + span;
        
        // res.start < start < res.end
        // res.start < end < res.end
        // start < res < end 
        
        // reservation.StartTime < startTime && startTime < reservation.EndTime ||
        // reservation.StartTime < endTime && endTime < reservation.EndTime ||
        // reservation.StartTime > startTime && endTime > reservation.EndTime) 
    }
}

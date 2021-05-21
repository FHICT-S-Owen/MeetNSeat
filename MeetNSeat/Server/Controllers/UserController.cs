﻿using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IManageUser _manageUser;

        public UserController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }

        [HttpGet]
        public ActionResult GetAllReservations()
        {
            var user = _manageUser.GetReservationByUser("108105466526811947195");
            return Ok(user);
        }
        
        [HttpPost]
        public void CreateReservation([FromBody] ReservationModel reservationModel)
        {
            var newReservation = _manageUser.AddReservation(reservationModel.Type, reservationModel.LocationId, reservationModel.UserId, reservationModel.Attendees, reservationModel.StartTime, reservationModel.EndTime);
        }

        [HttpDelete("{id:int}")]
        public bool DeleteResult(int id)
        {
            return _manageUser.DeleteReservation(id);
        }

        //[HttpGet]
        //public ActionResult GetAllLocations()
        //{
        //    var locations = _manageUser.GetAllLocations();
        //    return Ok(locations);
        //}

        [HttpGet("confirm")]
        public ActionResult ConfirmReservation([FromBody] int id, string ip)
        {
            var confirmed = _manageUser.ConfirmReservation(id, ip);
            if (confirmed)
            {
                return Ok();
            }
            return Problem();
        }

        [HttpGet("types")]
        public ActionResult GetAllRoomTypes()
        {
            var rooms = _manageUser.GetAllRoomTypes();
            return Ok(rooms);
        }
    }
}
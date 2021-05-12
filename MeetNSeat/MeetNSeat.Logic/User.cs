﻿using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class User : IManageUser
    {
        public string Id { get; set; }

        private List<Reservation> reservations = new List<Reservation>();
        private IReservationDal dal;

        public User(UserDto userDto)
        {
            Id = userDto.Id;
        }
        
        public User()
        {
            // Factory
            dal = ReservationFactory.CreateReservationDal();
        }

        public IReadOnlyCollection<Reservation> GetAllReservations()
        {
            reservations.Clear();
            dal.GetAllReservations().ForEach(
                dto => reservations.Add(new Reservation(dto)));
            return reservations.AsReadOnly();

        }

        public List<ManageReservationDto> GetReservationByUser(string userId)
        {
            return dal.GetReservationByUser(userId);
        }

        public bool AddReservation(string type, int locationId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            var isAvailable = true;
            // Retrieve rooms by type and location
            Room roomObject = new Room();
            var rooms = roomObject.GetAvailableRooms(type, locationId);

            var roomid = 0;

            Reservation reservationObject = new Reservation();
            var reservations = reservationObject.GetAllReservations();

            //TODO: Check if any room is available on given date
            // Loop trough reservations with given room id
            // Check if there is no reservation in given start and end

            foreach (var room in rooms)
            {
                foreach (var resDb in reservations)
                {
                    if (resDb.RoomId == room.RoomID)
                    {
                        if (resDb.StartTime < startTime && startTime < resDb.EndTime || 
                            resDb.StartTime < endTime && endTime < resDb.EndTime ||
                            resDb.StartTime > startTime && endTime > resDb.EndTime)
                        {
                            isAvailable = false;
                        }
                    }
                }

                roomid = room.RoomID;
            }
            if (isAvailable)
            {
                CreateReservationDto createReservationDto = new CreateReservationDto(roomid, userId, attendees, startTime, endTime);
                return dal.AddReservation(createReservationDto);
            }


            return false;
        }

        public bool DeleteReservation(int id)
        {
            return dal.RemoveReservation(id);
        }
        
        public UserDto ConvertToDto()
        {
            return new UserDto(Id);
        }
    }
}

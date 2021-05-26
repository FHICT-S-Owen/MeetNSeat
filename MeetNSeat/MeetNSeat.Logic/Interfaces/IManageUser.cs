﻿using System;
using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageUser
    {
        IReadOnlyCollection<Reservation> GetAllReservations();
        IReadOnlyCollection<ManageReservationDto> GetReservationByUser(string id);
        bool AddReservation(string type, int locationId, string userId, int attendees, DateTime startTime,
            DateTime endTime);

        bool EditReservation(Reservation reservation);
        bool ConfirmReservation(int id, string ip);
        bool DeleteReservation(int id);
        IReadOnlyCollection<Room> GetAllRoomTypes();

    }
}

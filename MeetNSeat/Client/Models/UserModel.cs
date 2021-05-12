﻿using System;

namespace MeetNSeat.Server.Models
{
    public class UserModel
    {
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public string UserId { get; set; }
        public int FeedbackId { get; set; }
        public int Attendees { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime IsConfirmed { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetNSeat.Client.Models
{
    public class FeedbackModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int FeedbackState { get; set; }

        public FeedbackModel(string description)
        {
            Description = description;
            FeedbackState = 1;
        }
    }
}

﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public class ReservationService
    {
        private readonly HttpClient _http;
        public ReservationService(HttpClient http)
        {
            _http = http;
        }

        public static async Task<string> DeleteReservation(int id)
        {
            using var client = new HttpClient();
            var msg = await client.DeleteAsync("https://localhost:5001/api/reservation/" + id);
            if (msg.IsSuccessStatusCode)
            {
                return "Your reservation has been canceled";
            }
            else
            {
                return "Something went wrong :( Please try again later";
            }
        }

        public static async Task<string> EditReservation(ReservationModel reservation)
        {
            using var client = new HttpClient();
            var msg = await client.PutAsJsonAsync("https://localhost:5001/api/reservation/", reservation);
            if(msg.IsSuccessStatusCode)
            {
                return "Your reservation has been edit";
            }
            else
            {
                return "Something went wrong :( Please try again later";
            }

        }
    }
}

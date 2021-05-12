using System;
using MeetNSeat.Client.Shared;

namespace MeetNSeat.Client.Models
{
	public class IssueModel
	{
		public string Description { get; set; }
		public int RoomId { get; set; }
		public string UserId { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsResolved { get; set; }

		public IssueModel(string description, int roomId,string userId)
		{
			Description = description;
			RoomId = roomId;
			UserId = userId;
		}
	}
}
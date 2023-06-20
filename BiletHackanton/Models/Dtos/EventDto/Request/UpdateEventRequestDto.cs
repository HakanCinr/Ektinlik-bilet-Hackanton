﻿namespace BiletHackanton.Models.Dtos.EventDto.Request
{
    public class UpdateEventRequestDto
    {
        public int CategoryID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string GoogleMapsLink { get; set; }
    }
}

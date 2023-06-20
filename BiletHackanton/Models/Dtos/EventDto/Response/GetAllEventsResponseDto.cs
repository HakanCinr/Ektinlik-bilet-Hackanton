namespace BiletHackanton.Models.Dtos.EventDto.Response
{
    public class GetAllEventsResponseDto
    {
        public int EventID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string GoogleMapsLink { get; set; }

    }
}

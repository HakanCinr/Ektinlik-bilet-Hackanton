namespace BiletHackanton.Models.Dtos.EventDto.Request
{
    public class CreateEventRequestDto
    {

        public int CategoryID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public decimal Cost { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string GoogleMapsLink { get; set; }
    }
}

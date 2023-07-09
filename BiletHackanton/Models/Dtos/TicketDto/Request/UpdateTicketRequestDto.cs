namespace BiletHackanton.Models.Dtos.TicketDto.Request
{
    public class UpdateTicketRequestDto
    {
        public int EventID { get; set; }
        public string TicketType { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}

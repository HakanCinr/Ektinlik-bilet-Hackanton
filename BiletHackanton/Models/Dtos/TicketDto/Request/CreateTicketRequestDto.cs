namespace BiletHackanton.Models.Dtos.TicketDto.Request
{
    public class CreateTicketRequestDto
    {
        public int EventID { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}

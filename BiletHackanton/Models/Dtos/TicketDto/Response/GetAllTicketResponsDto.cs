using BiletHackanton.Models.Orm;

namespace BiletHackanton.Models.Dtos.TicketDto.Response
{
    public class GetAllTicketResponsDto
    {
        public int TicketID { get; set; }
        public int EventID { get; set; }
        public string Title { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }

    }
}

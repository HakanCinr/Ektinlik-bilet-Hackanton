namespace BiletHackanton.Models.Orm
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int EventID { get; set; }

        public string TicketType { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }

        public Event Event { get; set; }
    }
}

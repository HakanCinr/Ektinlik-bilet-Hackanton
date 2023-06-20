using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace BiletHackanton.Models.Orm
{
    public class Event
    {
        public int EventID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string GoogleMapsLink { get; set; }

        public Category Category { get; set; }
        public List<Image> Images { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}

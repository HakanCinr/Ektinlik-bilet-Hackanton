using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BiletHackanton.Models.Orm
{
    public class Image
    {
        public int ImageID { get; set; }
        public int EventID { get; set; }
        public string? PosterURL { get; set; }
        public string ImageURL { get; set; }

        public Event Event { get; set; }
    }
}

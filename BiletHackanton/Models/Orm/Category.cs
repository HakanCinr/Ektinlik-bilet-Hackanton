using System.ComponentModel.DataAnnotations;

namespace BiletHackanton.Models.Orm
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

using BiletHackanton.Models.Orm;

namespace BiletHackanton.Models.Dtos.ImageDto.Response
{
    public class GetAllImageResponseDto
    {
        public int ImageID { get; set; }
        public int EventID { get; set; }
        public string ImageURL { get; set; }

        
    }
}
